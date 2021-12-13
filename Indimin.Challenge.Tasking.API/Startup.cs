using Indimin.Challenge.Logging.Filters;
using Indimin.Challenge.Tasking.API.Application.Configurations;
using Indimin.Challenge.Tasking.API.Application.Queries;
using Indimin.Challenge.Tasking.Domain.Models;
using Indimin.Challenge.Tasking.Infraestructure;
using Indimin.Challenge.Tasking.Infraestructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace Indimin.Challenge.Tasking.API
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
            services.AddTasking(Configuration);
            services.AddDbContext<TaskingDbContext>(options =>
            {
                options.UseSqlServer(Configuration["DatabaseSettings:ConnectionString"],
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("Indimin.Challenge.Tasking.API");
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
            }, ServiceLifetime.Scoped);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Indimin.Challenge.Tasking.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.InitializeDatabase();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Indimin.Challenge.Tasking.API v1"));
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
    public static class TaskingConfiguration
    {
        public static IServiceCollection AddTasking(this IServiceCollection services, IConfiguration configuration)
        {
            #region Configure ConnectionString
            services.Configure<DatabaseSettingsOptions>(configuration.GetSection(DatabaseSettingsOptions.Section));
            #endregion

            #region Repositories
            services.AddScoped<ICitizenTaskRepository, CitizenTaskRepository>();
            #endregion

            #region Queries
            services.AddScoped<ICitizenTaskQuery, CitizenTaskQuery>();
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
        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TaskingDbContext>();
                context.Database.Migrate();
            }
        }
    }
}
