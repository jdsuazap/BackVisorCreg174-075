namespace Application.Oraclet.File.Queries
{
    using Application.Oracle.File.Queries;
    using Core.Exceptions;
    using Core.Tools;
    using MediatR;
    using Microsoft.Extensions.Configuration;

    public class DownloadFileQueryHandler : IRequestHandler<DownloadFileQuery, (byte[], string)>
    {
        private readonly IConfiguration _configuration;

        public DownloadFileQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<(byte[], string)> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string basePath = _configuration["Rutas:Anexos"];

                string relativa = request.Url
                    .Replace("https://visorsolicitudes.eep.com.co:1000/AnexosVisor/", "");

                string rutaCompleta = Path.Combine(basePath, relativa);

                byte[] bytes = await System.IO.File.ReadAllBytesAsync(rutaCompleta);

                return (bytes, Funciones.GetContentType(request.NombreArchivo));

                //using var client = new HttpClient();
                //var bytes = await client.GetByteArrayAsync(request.Url, cancellationToken);
                //string contentType = Funciones.GetContentType(request.NombreArchivo);
                //return (bytes, contentType);
            }
            catch (Exception e)
            {
                throw new BusinessException(e.Message);
            }
        }
    }
}
