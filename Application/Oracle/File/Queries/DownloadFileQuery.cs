namespace Application.Oracle.File.Queries
{
    using MediatR;

    public class DownloadFileQuery : IRequest<(byte[], string)>
    {
        public string Url { get; set; }
        public string NombreArchivo { get; set; }
    }
}
