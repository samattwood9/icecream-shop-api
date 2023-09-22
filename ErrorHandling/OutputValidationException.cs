using System;

namespace api.ErrorHandling
{
    public class OutputValidationException : Exception
    {
        public OutputValidationException()
        {
        }

        public OutputValidationException(string message)
            : base(message)
        {
        }

        public OutputValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
