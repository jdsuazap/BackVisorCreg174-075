namespace Api.Controllers
{
    using Api.Responses;
    using Application.Oracle.TipoTecnologia.DTOs;
    using Application.Oracle.TipoTecnologia.Queries;
    using Core.Exceptions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class Tecnologias174Controller : ControllerBase
    {
        private readonly IMediator _mediator;

        public Tecnologias174Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Metodo para consultar todos los registros
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTecnologias", Name = "GetEntitiesTipoTecnologia")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetEntitiesTipoTecnologia()
        {
            try
            {
                var entities = await _mediator.Send(new TipoTecnologiaSearchAllQuery());                
                var response = new ApiResponse<List<TipoTecnologiaDTO>>(entities, 200);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error en la búsqueda. Detalle: {e.Message}");
            }
        }       
    }
}