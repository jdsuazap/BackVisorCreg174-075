namespace Api.Controllers
{
    using Api.Responses;
    using Application.SQLContext.SolServicioConexion.DTOs;
    using Application.SQLContext.SolServicioConexion.Queries;
    using Core.Exceptions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class SolServicioConexionController: ControllerBase
    {
        private readonly IMediator _mediator;
        public SolServicioConexionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Metodo para consultar un registro especifico
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpGet("GetById", Name = "GetEntitySolServicioConexion")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetEntitySolServicioConexion([FromQuery] SolServicioConexionSearchByIdQuery entity)
        {
            try
            {
                if (entity.Id <= 0)
                {
                    throw new ArgumentNullException(nameof(entity), "el valor de 'Id' no es válido");
                }

                var entityResp = await _mediator.Send(entity);
                var response = new ApiResponse<SolServicioConexionDTO>(entityResp, 200);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error en la búsqueda. Detalle: {e.Message}");
            }
        }

        /// <summary>
        /// Método para consultar Parametros Iniciales de formulario de CREG075
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        [HttpGet("GetInitialParams", Name = "GetParametrosInicialesCreg075")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetParametrosInicialesCreg075()
        {
            try
            {
                var entities = await _mediator.Send(new SolServicioConexionParametrosInicialesQuery());
                var response = new ApiResponse<SolServicioConexionParamsIniDTO>(entities, 200);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error en la búsqueda. Detalle: {e.Message}");
            }
        }
    }
}