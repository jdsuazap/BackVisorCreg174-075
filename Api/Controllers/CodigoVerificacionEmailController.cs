namespace Api.Controllers
{
    using Api.Responses;
    using Api.ViewsProcess;
    using Application.Oracle.CodigoVerificacionEmail.Commands;
    using Application.Oracle.Pasarela.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CodigoVerificacionEmailController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public CodigoVerificacionEmailController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        /// <summary>
        /// Metodo para Generar codigo de verificacion
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost("CrearCodigoVerificacion", Name = "CrearCodigoVerificacion")]
        [Consumes("application/json")]
        public async Task<IActionResult> CrearCodigoVerificacion([FromBody] CrearCodigoVerificacionCommand entity)
        {
            var entityResp = await _mediator.Send(entity);
            var response = new ApiResponse<object>(entityResp, 200);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para validar codigo de verificacion enviado por SMS
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost("VerificarCodigoSMS", Name = "VerificarCodigoSMS")]
        [Consumes("application/json")]
        public async Task<IActionResult> VerificarCodigoSMS([FromBody] VerificarCodigoQuery entity)
        {
            var entityResp = await _mediator.Send(entity);
            var response = new ApiResponse<object>(null, 0);

            if (entityResp)
            {
                var token = new TokenProcess(_configuration).GenerateToken(entity.Id.ToString(), "");
                Response.Headers.Add("Authorization", token);
                response = new ApiResponse<object>(entityResp, 200);
            }
            else
            {
                response = new ApiResponse<object>(entityResp, 400);
            }
            return Ok(response);
        }
    }
}
