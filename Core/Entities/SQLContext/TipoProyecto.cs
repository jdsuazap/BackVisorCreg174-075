#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class TipoProyecto : BaseEntity
    {
        public TipoProyecto()
        {
            //SolServicioConexionTipoProyectoPorReciboTecnicos = new HashSet<SolServicioConexionTipoProyectoPorReciboTecnico>();
        }

        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }

        //public virtual ICollection<SolServicioConexionTipoProyectoPorReciboTecnico> SolServicioConexionTipoProyectoPorReciboTecnicos { get; set; }
    }
}
