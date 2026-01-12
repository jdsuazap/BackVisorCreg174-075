namespace Api.Controllers
{
    using Api.Responses;
    using Application.Oracle.DocumentosXformulario.DTOs;
    using Application.Oracle.DocumentosXformulario.Queries;
    using Core.Exceptions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class DocumentosXformularioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DocumentosXformularioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Metodo para consultar todos los registros
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll", Name = "GetEntitiesDocumentosXformulario")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetEntitiesDocumentosXformulario()
        {
            try
            {
                var entities = await _mediator.Send(new DocumentosXformularioSearchAllQuery());
                var response = new ApiResponse<List<DocumentosXformularioDTO>>(entities, 200);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error en la búsqueda. Detalle: {e.Message}");
            }
        }
    }
}