using Core.Exceptions;
using Core.ModelResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Infrastructure.Filters
{
    public class GlobalExceptionFilter : IAsyncExceptionFilter
    {

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BusinessException))
            {
                var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                string? controllerName = controllerActionDescriptor?.ControllerName;
                string? actionMethod = controllerActionDescriptor?.ActionName;

                var exception = (BusinessException)context.Exception;
                string? user = context.HttpContext.Items.ContainsKey("UserID") ? context.HttpContext.Items["UserID"]?.ToString() : "0";

                ResponseAction resp;
               
                resp = new ResponseAction
                {
                    estado = false,
                    error = exception.Message,
                    mensaje = "Error interno del sistema" // Mensaje para el usuario
                };
               

                // Armamos respuesta al front y la enviamos
                var validation = new
                {
                    Status = 400,
                    data = new[] { resp }
                };

                context.Result = new BadRequestObjectResult(validation);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}
