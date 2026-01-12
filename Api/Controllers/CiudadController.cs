namespace Api.Controllers
{
    using Api.Responses;
    using Application.Oracle.Ciudad.DTOs;
    using Application.Oracle.Ciudad.Queries;
    using Core.Exceptions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class CiudadController: ControllerBase
    {
        private readonly IMediator _mediator;
        public CiudadController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Metodo para consultar todos los registros por codigo departamento
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpGet("GetDptoCiudad", Name = "GetEntitiesDptoCiudad")]
        public async Task<IActionResult> GetEntitiesDptoCiudad([FromQuery] CiudadSearchByDptoQuery entity)
        {
            try
            {
                if (string.IsNullOrEmpty(entity.CodDepartamento))
                {
                    throw new ArgumentNullException(nameof(entity), "el valor de 'Departamento' es invalido");
                }

                var entityResp = await _mediator.Send(entity);
                var response = new ApiResponse<List<CiudadDTO>>(entityResp, 200);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error en la búsqueda. Detalle: {e.Message}");
            }
        }
    }
}