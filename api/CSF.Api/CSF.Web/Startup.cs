using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using CSF.Data;
using CSF.Domain;
using System.Security.Claims;
using System;
using System.Linq;
using System.Threading.Tasks;
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentityProvider;

namespace CSF.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // Not a huge fan of having these here as it forces the web project to have references down to the data layer
            // Will consider adding a separate project to initialize these.
            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            services.AddAWSService<IAmazonCognitoIdentity>();
            services.AddAWSService<IAmazonCognitoIdentityProvider>();
            
            services.AddScoped<ConnectionFactory, ConnectionFactory>();
            services.AddScoped(typeof(Repository<>), typeof(Repository<>));
            services.AddScoped(typeof(BaseManager<>), typeof(BaseManager<>));
            services.AddSingleton(typeof(IConfiguration), Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "Cookies",
                AutomaticAuthenticate = false,
                AutomaticChallenge = false
            });

            app.UseClaimsTransformation(context =>
            {
                if (context.Principal.Identity.IsAuthenticated)
                {
                    context.Principal.Identities.First().AddClaim(new Claim("now", DateTime.Now.ToString()));
                }

                return Task.FromResult(context.Principal);
            });

            app.UseMvc(routes =>
                routes.MapRoute(
                    name: "default_route",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" }));
        }
    }
}
