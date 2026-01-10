#nullable disable
namespace Core.Entities.SQLContext
{
    public partial class ActividadEconomica : BaseEntity
    {
        public ActividadEconomica()
        {
            SolServicioConexions = new HashSet<SolServicioConexion>();
        }

        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }

        public virtual ICollection<SolServicioConexion> SolServicioConexions { get; set; }
    }
}
