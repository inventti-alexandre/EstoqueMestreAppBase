using System.IO;
using Entidades.Data;
using Entidades.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using MySQL.Data.EntityFrameworkCore.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace EstoqueCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EstoqueContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            // Add framework services.
            services.AddMvc();
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "EstoqueCore API",
                    Description = "Documentação da API de teste do Estoque com AspNet Core 1.1",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Rodrigo R Ferreira", Email = "rodrigorf33@techshift.com.br", Url = "http://twitter.com/rodrigorf"},
                    License = new License { Name = "Use under MIT", Url = "http://url.com" }
                });

                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "EstoqueCoreAPI.xml"); 
                c.IncludeXmlComments(xmlPath);    
            });        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, EstoqueContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            DbInitializer.Initialize(context);

             // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EstoqueCore API V1");
            });
        }
    }
}
