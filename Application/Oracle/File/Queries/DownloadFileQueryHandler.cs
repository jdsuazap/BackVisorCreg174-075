namespace Application.Oraclet.File.Queries
{
    using Application.Oracle.File.Queries;
    using Core.Exceptions;
    using MediatR;

    public class DownloadFileQueryHandler : IRequestHandler<DownloadFileQuery, (byte[], string)>
    {
        public async Task<(byte[], string)> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
        {
            try
            {
                using var client = new HttpClient();
                var bytes = await client.GetByteArrayAsync(request.Url, cancellationToken);
                //string contentType = Funciones.GetContentType(request.NombreArchivo);
                //return (bytes, contentType);
                return (bytes, null);
            }
            catch (Exception e)
            {
                throw new BusinessException(e.Message);
            }
        }
    }
}
