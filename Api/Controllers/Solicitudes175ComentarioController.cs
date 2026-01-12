namespace Api.Controllers
{
    using Api.Responses;
    using Application.SQLContext.SolServicioConexionComentario.DTOs;
    using Application.SQLContext.SolServicioConexionComentario.Queries;
    using Core.Exceptions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class Solicitudes175ComentarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public Solicitudes175ComentarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Metodo para consultar los comentarios realizados por los usuarios 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="BusinessException"></exception>
        [HttpGet("GetByRequestId",Name = "GetEntitiesSolServicioConexionComentarioByRequest")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetEntitiesSolServicioConexionComentarioByRequest([FromQuery] SolServicioConexionComentarioSearchByRequestIdQuery entity)
        {
            try
            {
                if (entity.Id <= 0)
                {
                    throw new ArgumentNullException(nameof(entity), "el valor de 'Id' no es válido");
                }

                var entityResp = await _mediator.Send(entity);

                var response = new ApiResponse<List<SolServicioConexionComentarioDTO>>(entityResp, 200);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error en la búsqueda. Detalle: {e.Message}");
            }
        }
        
    }
}