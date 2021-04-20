using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using Sample.API.Infrastructure;
using Sample.Database;
using Sample.Database.AutoMapper.Profiles;
using Sample.Database.Context;
using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using Sample.API.Controllers;
using Sample.API.AutoMapper;
using Sample.Database.Entities;
using Sample.Application.Category.GetAllUseCase;

namespace Sample.API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private IWebHostEnvironment WebHostEnvironment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;

            WebHostEnvironment = environment;
            Environment.CurrentDirectory = AppContext.BaseDirectory;
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();
            services.Configure<DatabaseConfig>(Configuration.GetSection("ConnectionStrings"));

            var connectionString = Environment.GetEnvironmentVariable("Sample_DB") ?? Configuration.GetConnectionString("SampleDatabase");
            services.AddDbContext<SampleContext>(options => options.UseNpgsql(connectionString));

            if (WebHostEnvironment.IsDevelopment())
                services.AddProblemDetails(x => x.Map<Exception>(exception => new ExceptionProblemDetail(exception)));

            services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddAutoMapper(typeof(ApplicationToApiProfile).Assembly, typeof(DBToApplicationProfile).Assembly);

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sample.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.ApiKey,
                        In = ParameterLocation.Header,
                        Scheme = "Bearer",
                        Description = "Please enter into field the word 'Bearer' following by space and JWT",
                        Name = "Authorization"
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            #endregion

            services.AddMediatR(typeof(CategoryResponse).Assembly, typeof(CategoryItem).Assembly, typeof(Category).Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample.API v1"));

            app.UseMigration();

            app.UseRouting();

            if (env.IsDevelopment())
                app.UseProblemDetails();
            else
                app.UseMiddleware<ExeptionMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
