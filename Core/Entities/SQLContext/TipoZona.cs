#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class TipoZona : BaseEntity
    {
        public TipoZona()
        {
            SolServicioConexionPredios = new HashSet<SolServicioConexionPredio>();
        }

        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }

        public virtual ICollection<SolServicioConexionPredio> SolServicioConexionPredios { get; set; }
    }
}
