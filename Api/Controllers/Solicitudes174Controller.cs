namespace Api.Controllers
{
    using Api.Responses;
    using Application.Oracle.SolConexionAutogen.DTOs;
    using Application.Oracle.SolConexionAutogen.Queries;
    using Core.Exceptions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class Solicitudes174Controller : ControllerBase
    {
        private readonly IMediator _mediator;
        public Solicitudes174Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetById", Name = "GetEntitySolicitud174")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetEntitySolicitud174([FromQuery] SolConexionAutogenSearchByIdQuery entity)
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

        [HttpGet("GetDatosGenerales", Name = "GetDatosGenerales174")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetDatosGenerales174()
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

        [HttpGet("GetTrafoPotenciaReservada", Name = "GetTrafoPotenciaReservada")]
        public async Task<IActionResult> GetTrafoPotenciaReservada([FromQuery] InfoFormularioSearchQuery parameters)
        {
            try
            {
                var entities = await _mediator.Send(parameters);
                var response = new ApiResponse<InfoFormularioDTO>(entities, 200);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error en la búsqueda. Detalle: {e.Message}");
            }
        }

    }
}