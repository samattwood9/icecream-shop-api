using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace api.ErrorHandling
{
    public class CustomExceptionAttribute : TypeFilterAttribute
    {
        public CustomExceptionAttribute() : base(typeof(HttpCustomExceptionFilterImpl))
        {

        }

        private class HttpCustomExceptionFilterImpl : IExceptionFilter
        {
            private readonly IWebHostEnvironment _env;
            private readonly ILogger<HttpCustomExceptionFilterImpl> _logger;

            public HttpCustomExceptionFilterImpl(IWebHostEnvironment env, ILogger<HttpCustomExceptionFilterImpl> logger)
            {
                _env = env;
                _logger = logger;
            }

            public void OnException(ExceptionContext context)
            {
                // process exception, assigning statusCode/message and logging accordingly 
                int statusCode;
                string message;
                switch (context.Exception)
                {
                    case InputValidationException inputValidationException:
                        _logger.LogWarning(SecurityEvents.InputValidationFailure, inputValidationException, inputValidationException.Message);
                        statusCode = StatusCodes.Status400BadRequest;
                        message = inputValidationException.Message;
                        break;
                    case OutputValidationException outputValidationException:
                        _logger.LogWarning(SecurityEvents.OutputValidationFailure, outputValidationException, outputValidationException.Message);
                        statusCode = StatusCodes.Status400BadRequest;
                        message = outputValidationException.Message;
                        break;
                    default:
                        _logger.LogError(new EventId(context.Exception.HResult), context.Exception, context.Exception.Message);
                        statusCode = StatusCodes.Status500InternalServerError;
                        message = "An unexpected error occurred. Please try again.";
                        break;
                }

                var json = new JsonErrorPayload
                {
                    Messages = new[] { message }
                };

                if (_env.IsDevelopment())
                {
                    // the whole exception cannot be assigned in .NET Core 3.1, at least without using a 3rd part like newtonsoft
                    // instead create an anon object w/ the key properties
                    // note that the logs can always be consulted for further details
                    json.DetailedMessage = new
                    {
                        // outer
                        Data = context.Exception?.Data,
                        HelpLink = context.Exception?.HelpLink,
                        Message = context.Exception?.Message,
                        Source = context.Exception?.Source,
                        StackTrace = context.Exception?.StackTrace,

                        // inner
                        InnerData = context.Exception?.InnerException?.Data,
                        InnerHelpLink = context.Exception?.InnerException?.HelpLink,
                        InnerMessage = context.Exception?.InnerException?.Message,
                        InnerSource = context.Exception?.InnerException?.Source,
                        InnerStackTrace = context.Exception?.InnerException?.StackTrace
                    };
                }

                var exceptionObject = new ObjectResult(json)
                {
                    StatusCode = statusCode
                };

                context.Result = exceptionObject;

                context.HttpContext.Response.StatusCode = statusCode;
            }
        }
    }

    public class JsonErrorPayload
    {
        public string[] Messages { get; set; }
        public object DetailedMessage { get; set; }
    }

    // Security event codes
    // Source for events: https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html
    // For more info regarding event codes/ids: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-3.1
    public class SecurityEvents
    {
        public const int InputValidationFailure = 1000;
        public const int OutputValidationFailure = 1001;
        public const int HighRiskUsage = 1002;
    }
}

