#nullable disable
namespace Core.Entities.SQLContext
{
    public partial class ComentarioAdjunto : BaseEntity
    {
        public int CodComentario { get; set; }
        public string FilePath { get; set; }
        public string FileRelativo { get; set; }
        public int? FileSize { get; set; }
        public string FileExt { get; set; }
        public bool? Estado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }

        public virtual Comentario CodComentarioNavigation { get; set; }
    }
}
