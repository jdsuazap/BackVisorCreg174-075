#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class TipoSolicitudServicio : BaseEntity
    {
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }

        public virtual ICollection<SolServicioConexionDetalle> SolServicioConexionDetalles { get; set; } = new List<SolServicioConexionDetalle>();
        public virtual ICollection<SolServicioConexionFactibilidad> SolServicioConexionFactibilidads { get; set; } = new List<SolServicioConexionFactibilidad>();
    }
}
