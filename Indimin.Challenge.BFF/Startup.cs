using Indimin.Challenge.BFF.APIs;
using Indimin.Challenge.BFF.Configurations;
using Indimin.Challenge.BFF.Services;
using Indimin.Challenge.Logging.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;

namespace Indimin.Challenge.BFF
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

            services.Configure<ServicesOptions>(Configuration.GetSection(ServicesOptions.Section));

            services.AddHttpClient(nameof(CitizensClient))
                .ConfigureHttpClient((serviceProvider, httpClient) =>
                {
                    var httpClientOptions = serviceProvider
                        .GetRequiredService<IOptions<ServicesOptions>>().Value;

                    httpClient.BaseAddress = new System.Uri(httpClientOptions.Citizens.UrlBase);
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                });

            services.AddSingleton<CitizensClient>();

            services.AddHttpClient(nameof(CitizenTasksClient))
                .ConfigureHttpClient((serviceProvider, httpClient) =>
                {
                    var httpClientOptions = serviceProvider
                        .GetRequiredService<IOptions<ServicesOptions>>().Value;

                    httpClient.BaseAddress = new System.Uri(httpClientOptions.CitizenTasks.UrlBase);
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                });

            services.AddSingleton<CitizenTasksClient>();

            services.AddScoped<IBFFService, BFFService>();


            services.AddControllers(options => options.Filters.Add<LoggingFilter>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Indimin.Challenge.BFF", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Indimin.Challenge.BFF v1"));
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
}
