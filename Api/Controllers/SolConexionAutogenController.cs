namespace Api.Controllers
{
    using Api.Responses;
    using Application.Oracle.SolConexionAutogen.DTOs;
    using Application.Oracle.SolConexionAutogen.Queries;
    using Core.Exceptions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    //[Authorize(Policy = "ShouldBeAnAdminOrCreg")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class SolConexionAutogenController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SolConexionAutogenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetById", Name = "GetEntitySolConexionAutogen")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetEntitySolConexionAutogen([FromQuery] SolConexionAutogenSearchByIdQuery entity)
        {
            try
            {
                if (entity.Id <= 0)
                {
                    throw new ArgumentNullException(nameof(entity), "el valor de 'Id' no es válido");
                }
                var entityResp = await _mediator.Send(entity);
                var response = new ApiResponse<SolConexionAutogenDTO>(entityResp, 200);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error en la búsqueda. Detalle: {e.Message}");
            }
        }

        [HttpGet("GetInitialParams", Name = "GetParametrosIniciales")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetParametrosIniciales()
        {
            try
            {
                var entities = await _mediator.Send(new SolConexionAutogenParametrosInicialesQuery());
                var response = new ApiResponse<SolConexionAutogenParamsIniDTO>(entities, 200);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error en la búsqueda. Detalle: {e.Message}");
            }
        }

    }
}