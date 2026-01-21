namespace Api.Controllers
{
    using Api.Responses;
    //using Application.SQLContext.SolReciboTecnico.Queries;
    //using Application.SQLContext.SolServicioConexionReciboTecnico.DTOs;
    using Core.Exceptions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class Solicitudes075ReciboTecnicoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public Solicitudes075ReciboTecnicoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Metodo para consultar un registro especifico
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        //[HttpGet("GetById", Name = "GetEntitySolReciboTecnico")]
        //[Consumes("application/json")]
        //public async Task<IActionResult> GetEntitySolReciboTecnico([FromQuery] SolServicioConexionReciboTecnicoSearchByIdQuery entity)
        //{
        //    try
        //    {
        //        if (entity.Id <= 0)
        //        {
        //            throw new ArgumentNullException(nameof(entity), "el valor de 'Id' no es válido");
        //        }

        //        var entityResp = await _mediator.Send(entity);
        //        var response = new ApiResponse<List<SolServicioConexionReciboTecnicoPorEtapasDTO>>(entityResp, 200);
        //        return Ok(response);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new BusinessException($"Error en la búsqueda. Detalle: {e.Message}");
        //    }
        //}
    }
}