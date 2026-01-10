namespace Application.SQLContext.File.DTOs
{
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Almacenamiento Imagen
    /// </summary>
    public class FileDTO
    {
        public List<IFormFile> Files { get; set; }
        public int IdPathFileServer { get; set; }
        public string Carpeta { get; set; }
    }
}
