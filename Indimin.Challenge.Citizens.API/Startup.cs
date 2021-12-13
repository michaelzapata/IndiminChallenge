using Indimin.Challenge.Citizens.API.Application.Infraestructure;
using Indimin.Challenge.Citizens.API.Application.Infraestructure.Contracts;
using Indimin.Challenge.Citizens.API.Application.Infraestructure.Repositories;
using Indimin.Challenge.Citizens.API.Application.Options;
using Indimin.Challenge.Logging.Filters;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Indimin.Challenge.Citizens.API
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddControllers(options => options.Filters.Add<LoggingFilter>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Indimin.Challenge.Citizens.API", Version = "v1" });
            });
            services.AddBusinessConfiguration(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Indimin.Challenge.Citizens.API v1"));
            }

            app.AddLoggingMiddleware();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public static class BusinessConfiguration
    {
        public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            #region Database Options
            services.Configure<DatabaseSettingsOptions>(configuration.GetSection(DatabaseSettingsOptions.Section));
            #endregion

            #region Infraestructure Configuration
            services.AddScoped<ICitizenContext, CitizenContext>();
            services.AddScoped<ICitizenRepository, CitizenRepository>();
            #endregion

            #region Configuracion Logging
            services.AddLogging(Assembly.GetExecutingAssembly());
            #endregion

            #region AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #endregion

            #region MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());
            #endregion



            return services;
        }
    }
}
