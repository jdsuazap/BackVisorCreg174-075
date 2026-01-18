namespace Api.Controllers
{
    using Application.Oracle.File.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FilesController(IMediator mediator)
        {
            _mediator = mediator;
        }       

        [HttpPost("DownloadFile", Name = "Descargar")]
        [Consumes("application/json")]
        public async Task<IActionResult> Descargar([FromBody] DownloadFileQuery data)
        {
            var resp = await _mediator.Send(data);
            return File(resp.Item1, resp.Item2, data.NombreArchivo);
        }
    }
}