using api.Domains.Interfaces;
using api.ErrorHandling;
using api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SimpleInjector;

namespace api
{
    public class Startup
    {
        private Container container = new SimpleInjector.Container();
    
        public Startup(IConfiguration configuration)
        {
            // Set to false. This will be the default in v5.x (simple injector) and going forward.
            container.Options.ResolveUnregisteredConcreteTypes = false;
  
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(config => config.Filters.Add(new CustomExceptionAttribute()));

             services.AddDbContext<Context>(options => options
                .UseSqlite(Configuration.GetConnectionString("IcecreamDatabase"))
                //.UseInMemoryDatabase(databaseName: "icecream_db")
                //.EnableSensitiveDataLogging()
            );
           
            // Configure CORS
            services.AddCors(options =>
            {
                // NOTE: this could be where a whitlist of headers etc is applied.
                options.AddPolicy("icecream", policy =>
                {
                    policy.WithOrigins("https://icecream.com")
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .AllowAnyMethod();

                    // additional origins can be specified if required, like this...
                    //policy.WithOrigins("")
                        //.AllowAnyHeader()
                        //.AllowAnyMethod();
                });
            });

            services.AddControllersWithViews();

            // Register the Swagger services
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v0.2", new OpenApiInfo
                {
                    Version = "v0.2",
                    Title = "Icecream Shop API",
                    Description = "An icecream shop's REST API.",
                });
            });

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            // Configure SimpleInjector (used to inject domains into controllers)
            #region SimpleInjector
            // Sets up the basic configuration that for integrating Simple Injector with
            // ASP.NET Core by setting the DefaultScopedLifestyle, and setting up auto cross wiring.
            services.AddSimpleInjector(container, options =>
            {
                // AddAspNetCore() wraps web requests in a Simple Injector scope and
                // allows request-scoped framework services to be resolved.
                options.AddAspNetCore()
                // Ensure activation of a specific framework type to be created by
                // simple Injector instead of the built-in configuration system.
                // All calls are optional. You can enable what you need. For instance,
                // PageModels and TagHelpers are not needed when you build a Web API.
                .AddControllerActivation()
                .AddViewComponentActivation()
                .AddPageModelActivation()
                .AddTagHelperActivation();

                // Optionally, allow application components to depend on the non-generic
                // ILogger (Microsoft.Extensions.Logging) or IStringLocalizer
                // (Microsoft.Extensions.Localization) abstractions.
                options.AddLogging();
                options.AddLocalization();
            });

            InitializeContainer();
            #endregion
        }

        private void InitializeContainer()
        {
            // Add application services
            container.Register<ICustomer, api.Domains.Customer>(Lifestyle.Scoped);
            container.Register<IFlavour, api.Domains.Flavour>(Lifestyle.Scoped);
            container.Register<ITopping, api.Domains.Topping>(Lifestyle.Scoped);
            container.Register<ISeed, api.Domains.Seed>(Lifestyle.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            // ASP.NET middleware
            app.UseRouting();
            app.UseCors("icecream");

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v0.2/swagger.json", "v0.2");
                c.RoutePrefix = string.Empty;
            });

            // Configure endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Always verify the container
            container.Verify();
        }
    }
}