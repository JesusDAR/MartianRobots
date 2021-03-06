using AutoMapper;
using MartianRobots.Core.Repositories;
using MartianRobots.Core.Repositories.Interfaces;
using MartianRobots.WebApi.Services;
using MartianRobots.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials().WithOrigins("http://localhost:8080", "http://localhost:8081")
                    );
            });
            services.RegisterServices();
            services.RegisterRepositories();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MartianRobots.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MartianRobots.WebApi v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }


    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IRobotServices, RobotServices>();
            services.AddTransient<IMarsServices, MarsServices>();
            services.AddTransient<IInformationServices, InformationServices>();
            services.AddTransient<IVisitedServices, VisitedServices>();
            return services;
        }
    }
        
    public static class RepositoryExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection repositories)
        {
            repositories.AddScoped<IInformationRepository, InformationRepository>();
            repositories.AddScoped<IMarsRepository, MarsRepository>();
            repositories.AddScoped<IRobotRepository, RobotRepository>();
            repositories.AddScoped<IVisitedRepository, VisitedRepository>();
            return repositories;
        }
    }
}
