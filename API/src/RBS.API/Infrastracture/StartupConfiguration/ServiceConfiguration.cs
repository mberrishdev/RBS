using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using RBS.API.Filters;
using RBS.API.Infrastracture.Options;
using RBS.Application;
using RBS.Persistence;

namespace RBS.API.Infrastracture.StartupConfiguration
{
    public static class ServiceConfiguration
    {
        public static WebApplicationBuilder ConfigureService(this WebApplicationBuilder builder)
        {
            IServiceCollection services = builder.Services;
            IConfiguration configuration = builder.Configuration;

            // Add services to the container.

            services.AddPersistence(configuration);
            services.AddApplication(configuration);

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            services.AddVersioning();
            services.AddSwagger();

            services.AddHealthChecks();

            services.AddCors();

            return builder;
        }


        private static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        private static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.ConfigureOptions<ConfigureSwaggerOptions>()
                .AddSwaggerGen(swagger =>
                {
                    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer w9ADFAqio8bjzlao10385Adjeb\"",
                    });

                    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                          {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    }
                                },
                                Array.Empty<string>()
                            }
                          });

                    // Set the comments path for the Swagger JSON and UI.
                    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    //swagger.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
                    swagger.DocumentFilter<HealthChecksFilter>();
                });

            return services;
        }

        private static IServiceCollection AddCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policyBuilder =>
                    {
                        var allowedOrigins = "http://192.168.1.123:4200";

                        policyBuilder.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader().AllowAnyMethod().AllowCredentials();

                    });
            });

            return services;
        }
    }
}
