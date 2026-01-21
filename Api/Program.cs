using Api;
using Api.Responses;
using Application.Interfaces;
using Application.Services;
using FluentValidation.AspNetCore;
using Infrastructure.Extensions;
using Infrastructure.Filters;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SoapCore;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Net;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configuracion para implementar AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(Assembly.Load("Application"));

// Configuracion para implementar MediatR
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
    //options.Filters.Add<RolesFilter>();
    //options.Filters.Add<ResultFilter>();
})
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

        // Opciones de SOAP
        options.SerializerSettings.Formatting = Formatting.Indented;
        //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
        // Configura Newtonsoft.Json para que las propiedades se serialicen en minúsculas
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    })
    .ConfigureApiBehaviorOptions(options =>
    {
        // Configuracion para definir si el ApiController controla las validaciones de ModelState
        // Si deseamos solo utilizar FluentValidation como validador debemos colocarlo en false
        options.SuppressModelStateInvalidFilter = false;
    })
    .AddFluentValidation(options =>
    {
        //options.AutomaticValidationEnabled = false;
        options.DisableDataAnnotationsValidation = true;
        options.ConfigureClientsideValidation(enabled: false);
        // Colocar true si se desea que Fluentvalidation se ejecute antes de llegar al controlador
        // Se buscan todas las validaciones de todos los modelos
        options.ImplicitlyValidateChildProperties = false;
        options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        //options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });
//.SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
//ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;

// Configuracion de opciones
builder.Services.AddOptions(builder.Configuration);

// Configuracion para la conexion a la Base de Datos
builder.Services.AddDbContexts(builder.Configuration);

// Habilita servicios SOAP
builder.Services.AddSoapCore();

// Inyeccion de Dependencias
builder.Services.AddServices();

// Servicio Generico de FluentValidation
builder.Services.AddScoped<IGenericValidation, GenericValidation>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
builder.Services.AddSwagger(builder.Configuration, xmlFile);

// Configuracion para controlar CORS
builder.Services.AddCorsApp(builder.Configuration);

// Configuracion para Socket SignalR
builder.Services.AddSignalR(options => {
    options.EnableDetailedErrors = true;
});

// Configuracion para la Autenticacion (JWT)
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // Validar el Emisor
        ValidateAudience = true, // Vaidar la audiencia
        ValidateLifetime = true, // Validar el tiempo de vida del token
        ClockSkew = TimeSpan.Zero, // Deshabilitar tiempo minimo de expiracion por default
        ValidateIssuerSigningKey = true, // Validar la firma del emisor
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretKey"]))
    };
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = (context) =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.HttpContext.Items.Add("TipoError", "Expired");
            }
            else
            {
                context.HttpContext.Items.Add("TipoError", "Invalid");
            }

            return Task.CompletedTask;
        },
        OnChallenge = async (context) =>
        {
            int codigoResponse = 401;
            string error = "";

            // this is a default method
            // the response statusCode and headers are set here
            context.HandleResponse();

            // AuthenticateFailure property contains 
            // the details about why the authentication has failed
            if (context.AuthenticateFailure != null)
            {
                if (context.HttpContext.Items.ContainsKey("TipoError"))
                {
                    string tipoError = context.HttpContext.Items["TipoError"].ToString();

                    // AuthenticateFailure property contains 
                    // the details about why the authentication has failed
                    if (tipoError.Equals("Expired"))
                    {
                        error = "La sesión del usuario está vencida, por favor ingrese de nuevo al sistema";
                        codigoResponse = (int)HttpStatusCode.Forbidden;
                    }
                    else if (tipoError.Equals("Invalid"))
                    {
                        error = "La autenticación del usuario es inválida";
                        codigoResponse = (int)HttpStatusCode.Unauthorized;
                    }

                    // Write to the response in any way you wish
                    context.Response.StatusCode = codigoResponse;
                    context.Response.Headers.Append("WWW-Authenticate", $"Bearer error='{context.Error}'");

                    // we can write our own custom response content here
                    var response = ErrorResponse.GetErrorDescripcion(false, error, context.ErrorDescription, codigoResponse);
                    await context.Response.WriteAsJsonAsync(response);
                }
                else
                {
                    // Write to the response in any way you wish
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Response.Headers.Append("WWW-Authenticate", $"Bearer error='{context.Error}'");

                    // we can write our own custom response content here
                    var response = ErrorResponse.GetErrorDescripcion(false, "La autenticación del usuario es inválida", context.ErrorDescription, 401);
                    await context.Response.WriteAsJsonAsync(response);
                    //await context.Response.CompleteAsync();
                }
            }
            else
            {
                error = "La autenticación del usuario es inválida";
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.Headers.Append("WWW-Authenticate", $"Bearer error='{error}'");
                var response = ErrorResponse.GetErrorDescripcion(false, error, "", codigoResponse);
                await context.Response.WriteAsJsonAsync(response);
                //await context.Response.CompleteAsync();
            }

            await Task.CompletedTask;
        }
    };
});


builder.Services.AddHttpContextAccessor(); // Para poder utilizar HttpContext en ShouldBeAnAdminRequirementHandler
builder.Services.AddScoped<IGenericHttpContext, GenericHttpContext>();

// Configuracion para controlar Filtros del Request y las Validaciones de las entidades
builder.Services.AddMvc();

string appsettingFile = $"appsettings.{builder.Environment.EnvironmentName}.json";

builder.Configuration
    .AddJsonFile(appsettingFile, optional: true, reloadOnChange: true);

// Rate Limit: obtener configuración
_ = int.TryParse(builder.Configuration["RateLimit:Authenticated:FixedWindow:PermitLimit"], out int authFixedWindowPermit);
_ = int.TryParse(builder.Configuration["RateLimit:Authenticated:FixedWindow:Time"], out int authFixedWindowTime);
_ = int.TryParse(builder.Configuration["RateLimit:Authenticated:FixedWindow:QueueLimit"], out int authFixedWindowQueue);

_ = int.TryParse(builder.Configuration["RateLimit:Authenticated:Concurrency:PermitLimit"], out int authConcurrencyPermit);
_ = int.TryParse(builder.Configuration["RateLimit:Authenticated:Concurrency:QueueLimit"], out int authConcurrencyQueue);

_ = int.TryParse(builder.Configuration["RateLimit:Anonymous:FixedWindow:PermitLimit"], out int anonFixedWindowPermit);
_ = int.TryParse(builder.Configuration["RateLimit:Anonymous:FixedWindow:Time"], out int anonFixedWindowTime);
_ = int.TryParse(builder.Configuration["RateLimit:Anonymous:FixedWindow:QueueLimit"], out int anonFixedWindowQueue);

_ = int.TryParse(builder.Configuration["RateLimit:Anonymous:Concurrency:PermitLimit"], out int anonConcurrencyPermit);
_ = int.TryParse(builder.Configuration["RateLimit:Anonymous:Concurrency:QueueLimit"], out int anonConcurrencyQueue);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!new string[] { ApiEnvironments.Production }.Contains(app.Environment.EnvironmentName))
{
    app.UseDeveloperExceptionPage();

    // Configuracion Swagger
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(builder.Configuration["Swagger:Url"], builder.Configuration["Swagger:DefinitionName"]);
        options.RoutePrefix = builder.Configuration["Swagger:RutaSwagger"];

        options.DocumentTitle = builder.Configuration["Swagger:DocumentTitle"];
        options.DocExpansion(DocExpansion.None);
        options.DisplayRequestDuration();
    });
}

// Habilitamos los CORS
app.UseCors("ApiCors");

app.UseHttpsRedirection();

// Version Net 5
app.UseRouting();

// Configuracion JWT
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
