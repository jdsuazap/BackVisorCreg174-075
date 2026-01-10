namespace Application.SQLContext.File.CustomEntities
{
    using Core.CustomEntities;

    public class RespFile
    {
        public List<FileResponse> Files { get; set; } = new List<FileResponse>();
        public FileResponse File { get; set; } = new FileResponse();
    }
}
