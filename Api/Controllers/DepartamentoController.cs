namespace Api.Controllers
{
    using Api.Responses;
    using Application.Oracle.Departamento.DTOs;
    using Application.Oracle.Departamento.Queries;
    using Core.Exceptions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    //[Authorize(Policy = "ShouldBeAnAdmin")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class DepartamentoController: ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartamentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Metodo para consultar todos los registros
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll", Name = "GetEntitiesDepartamento")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetEntitiesDepartamento()
        {
            try
            {
                var entities = await _mediator.Send(new DepartamentoSearchAllQuery());
                var response = new ApiResponse<List<DepartamentoDTO>>(entities, 200);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error en la búsqueda. Detalle: {e.Message}");
            }
        }
    }
}