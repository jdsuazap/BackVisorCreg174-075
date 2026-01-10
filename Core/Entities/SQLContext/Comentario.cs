#nullable disable
namespace Core.Entities.SQLContext
{
    public partial class Comentario : BaseEntity
    {
        public Comentario()
        {
            ComentarioAdjuntos = new HashSet<ComentarioAdjunto>();
        }

        public int? CodComentario { get; set; }
        public int CodFormularioPrincipal { get; set; }
        public int CodLlaveFormularioPrincipal { get; set; }
        public int CodUsuario { get; set; }
        public bool IsGestor { get; set; }
        public string DescripcionComentario { get; set; }
        public bool? Estado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }

        public virtual ICollection<ComentarioAdjunto> ComentarioAdjuntos { get; set; }
    }
}
