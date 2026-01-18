namespace Api.Controllers
{
    using Api.Responses;
    using Application.SQLContext.SolServicioConexionFactibilidad.DTOs;
    using Application.SQLContext.SolServicioConexionFactibilidad.Queries;
    using Core.Exceptions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class Solicitudes075FactibilidadController: ControllerBase
    {
        private readonly IMediator _mediator;
        public Solicitudes075FactibilidadController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Metodo para consultar un registro especifico
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpGet("GetById", Name = "GetEntitySolServicioConexionFactibilidad")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetEntitySolServicioConexionFactibilidad([FromQuery] SolServicioConexionFactibilidadSearchByIdQuery entity)
        {
            try
            {
                if (string.IsNullOrEmpty(entity.CodSolServicioConexion.ToString()))
                {
                    throw new ArgumentNullException(nameof(entity), "el valor de 'CodSolServicioConexion' no es válido");
                }

                var entityResp = await _mediator.Send(entity);
                var response = new ApiResponse<SolServicioConexionFactibilidadDTO>(entityResp, 200);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error en la búsqueda. Detalle: {e.Message}");
            }
        }
    }
}
