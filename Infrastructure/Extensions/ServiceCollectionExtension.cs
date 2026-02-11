namespace Infrastructure.Extensions
{
    using Core.CustomEntities;
    using Core.Enumerations;
    using Core.Exceptions;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    using Core.Options;
    using Core.Services.Oracle;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;
    using Infrastructure.Repositories;
    using Infrastructure.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Oracle.ManagedDataAccess.Client;
    using System.Data;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {     
            string oracleConnEEP = configuration.GetConnectionString("ConexionOracleEEP")
                ?? throw new BusinessException($"No existe cadena de conexión para 'ConexionOracleEEP' ");

            var oracleConectionEEP = new DbConnectionFactoryModel() { ConnectionString = oracleConnEEP, TipoDB = EnumDatabaseType.Oracle };

            var connections = new Dictionary<string, DbConnectionFactoryModel>
            {
                { EnumConnectionStrings.BaseDeDatoOracleEEP.ToString(), oracleConectionEEP }
            };

            string oracleConnSpard = configuration.GetConnectionString("ConexionOracleSpard")
                ?? throw new BusinessException($"No existe cadena de conexión para 'ConexionOracleSpard' ");

            var oracleConectionSpard = new DbConnectionFactoryModel() { ConnectionString = oracleConnSpard, TipoDB = EnumDatabaseType.Oracle };

            connections.Add(EnumConnectionStrings.BaseDeDatoOracleSpard.ToString(), oracleConectionSpard);

            services.AddSingleton<IDictionary<string, DbConnectionFactoryModel>>(connections);
           
            services.AddDbContext<DbOracleContext>(options =>
            {
                options.UseOracle(oracleConnEEP);
            }, ServiceLifetime.Scoped);

            services.AddDbContext<DbSpardContext>(options =>
            {
                options.UseOracle(oracleConnSpard);
            }, ServiceLifetime.Scoped);

            // Configuración Dapper
            services.AddScoped<IDbConnection>(sp =>
            {
                var conn = new OracleConnection(oracleConnEEP);
                conn.Open();
                return conn;
            });

            services.AddScoped<IDbConnection>(sp =>
            {
                var conn = new OracleConnection(oracleConnSpard);
                conn.Open();
                return conn;
            });

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuraciones de Paginacion y Password
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));
            services.Configure<PathOptions>(options => configuration.GetSection("PathOptions").Bind(options));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Inyección de Depencias
            /* Suponiendo que cambiamos de motor de Base de Datos, este proceso nos facilita que 
             * no nos toque reestructurar el proyecto para acoplarlo a cada motor de Base de datos.
             */         

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext?.Request;
                var absoluteUri = string.Concat(request?.Scheme, "://", request?.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });          
            
            services.AddTransient<IDocumentosXformularioService, DocumentosXformularioService>();            
            services.AddTransient<ISolConexionAutogenService, SolConexionAutogenService>();            
            services.AddTransient<ISolServicioConexionService, SolServicioConexionService>();
            services.AddTransient<IDepartamentoService, DepartamentoService>();          
            services.AddTransient<ITipoIdentificacionService , TipoIdentificacionService>();
            services.AddTransient<ITipoTecnologiaService, TipoTecnologiaService>();
            services.AddTransient<ITipoTramiteVisitaService, TipoTramiteVisitaService>();
            services.AddTransient<IActividadEconomicaService, ActividadEconomicaService>();
            services.AddTransient<IPersonaAutorizaReciboService, PersonaAutorizaReciboService>();
            services.AddTransient<ITipoTramiteVisitaService, TipoTramiteVisitaService>();
            services.AddTransient<ICreg_TransformadorService, Creg_TransformadorService>();
            services.AddTransient<ICregCiudadService, CregCiudadService>();
            services.AddTransient<ISolServicioConexionFactibilidadService, SolServicioConexionFactibilidadService>();


            //services.AddTransient<ISolServicioConexionReciboTecnicoService, SolServicioConexionReciboTecnicoService>();
            //services.AddTransient<IMotivoProrrogaService, MotivoProrrogaService>();          
            //services.AddTransient<IPasosSolConexionAutogenService, PasosSolConexionAutogenService>();
            //services.AddTransient<IPasosSolServicioConexionService, PasosSolServicioConexionService>();
            //services.AddTransient<ISolServicioConexionComentarioService, SolServicioConexionComentarioService>();                      
            //services.AddTransient<ISolServicioConexionDisenioService, SolServicioConexionDisenioService>();
            //services.AddTransient<ISolServicioConexionComentarioService , SolServicioConexionComentarioService>();
            //services.AddTransient<ISolServicioConexionReviewsService , SolServicioConexionReviewsService> ();
            //services.AddTransient<ISolConexionAutogenComentarioService, SolConexionAutogenComentarioService>();

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration, string xmlFileName)
        {
            // Configuracion Swagger
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc(configuration["Swagger:Version"], new OpenApiInfo
                {
                    Title = configuration["Swagger:Title"],
                    Version = configuration["Swagger:Version"],
                    Description = configuration["Swagger:AppDescription"],
                    /*Contact = new OpenApiContact()
                    {
                        Name = configuration["Swagger:contactName"],
                        Email = configuration["Swagger:contactEmail"],
                        Url = new Uri(configuration["Swagger:contactWeb"])
                    }*/
                });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);

                doc.AddSecurityDefinition(configuration["Swagger:SecurityName"], new OpenApiSecurityScheme
                {
                    Description = configuration["Swagger:DescriptionToken"],
                    Name = configuration["Swagger:HeaderName"],
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                doc.AddSecurityRequirement(new OpenApiSecurityRequirement {
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
            });

            return services;
        }

        public static IServiceCollection AddCorsApp(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? null;

            // Configuracion CORS
            services.AddCors(options =>
            {
                options.AddPolicy("ApiCors", builder =>
                {
                    builder
                    //.AllowAnyOrigin()
                    // Esto no va en produccion, sólo local
                    .WithOrigins(allowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithExposedHeaders("Authorization") // Expone el token para que las Apps lo puedan ver
                    //.SetIsOriginAllowed(_ => true) // permite cualquier origen
                    .AllowCredentials(); // necesario para SignalR;
                });
            });

            return services;
        }
    }
}
