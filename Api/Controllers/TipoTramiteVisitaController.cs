namespace Api.Controllers
{
    using Api.Responses;
    using Application.Oracle.TipoTramiteVisita.DTOs;
    using Application.Oracle.TipoTramiteVisita.Queries;
    using Core.Exceptions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;


    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class TipoTramiteVisitaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TipoTramiteVisitaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Metodo para consultar todos los registros
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll", Name = "GetEntitiesTipoTramiteVisita")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetEntitiesTipoTramiteVisita()
        {
            try
            {
                var entities = await _mediator.Send(new TipoTramiteVisitaSearchAllQuery());                
                var response = new ApiResponse<List<TipoTramiteVisitaDTO>>(entities, 200);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error en la búsqueda. Detalle: {e.Message}");
            }
        }
    }
}