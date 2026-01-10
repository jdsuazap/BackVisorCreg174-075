#nullable disable
namespace Core.Entities.SQLContext
{
    public partial class TipoEstado : BaseEntity
    {
        public TipoEstado()
        {
            Estados = new HashSet<Estado>();
        }

        public string TeDescripcion { get; set; }
        public bool? TeEstado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }

        public virtual ICollection<Estado> Estados { get; set; }
    }
}
