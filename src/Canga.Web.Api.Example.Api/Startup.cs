using System;
using System.IO;
using System.Reflection;
using Canga.Web.Api.Example.Service.Albums;
using Canga.Web.Api.Example.Storage.Albums;
using Canga.Web.Api.Example.Storage.Model;
using Canga.Web.Api.Example.Storage.SampleData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Canga.Web.Api.Example.Api
{
#pragma warning disable 1591
    public class Startup
    {
        public static readonly string ApiName = typeof(Startup).Module.Name.Replace(".dll", "");
        public static readonly string ApiVersion = "v1";
        public static string ApiDescription = "An example Web API setup";
        
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            ConfigureApiDocs(services);
            ConfigureBusinessLayer(services);
        }

        private void ConfigureBusinessLayer(IServiceCollection services)
        {
            var albumsDataPath = "/albums";
            var photosDataPath = "/photos";
            services.AddSingleton(typeof(ISampleDataReader), provider => new SampleDataDownloader(albumsDataPath, photosDataPath));

            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<IAlbumService, AlbumService>();
        }

        private void ConfigureApiDocs(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
               {
                   c.SwaggerDoc(ApiVersion,
                       new Info
                       {
                           Version = ApiVersion,
                           Title = ApiName,
                           Description = ApiDescription
                       });
            
                   // Set the comments path for the Swagger JSON and UI.
                   var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                   var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                   c.IncludeXmlComments(xmlPath);
                   c.CustomSchemaIds(s => s.FullName);
               });
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
            });
   
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ApiName);
                c.RoutePrefix = "docs"; // {api-url}/docs/ will open Swagger UI
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
#pragma warning restore 1591
}