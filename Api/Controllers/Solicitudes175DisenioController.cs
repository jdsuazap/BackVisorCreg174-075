namespace Api.Controllers
{
    using Api.Responses;
    using Application.SQLContext.SolServicioConexionDisenio.DTOs;
    using Application.SQLContext.SolServicioConexionDisenio.Queries;
    using Core.Exceptions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class Solicitudes175DisenioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public Solicitudes175DisenioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Metodo para consultar un registro especifico
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpGet("GetById", Name = "GetEntitySolServicioConexionDisenio")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetEntitySolServicioConexionDisenio([FromQuery] SolServicioConexionDisenioSearchByIdQuery entity)
        {
            try
            {
                if (string.IsNullOrEmpty(entity.Id.ToString()))
                {
                    throw new ArgumentNullException(nameof(entity), "el valor de 'Id' no es válido");
                }

                var entityResp = await _mediator.Send(entity);
                var response = new ApiResponse<SolServicioConexionDisenioDTO>(entityResp, 200);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error en la búsqueda. Detalle: {e.Message}");
            }
        }

    }
}
