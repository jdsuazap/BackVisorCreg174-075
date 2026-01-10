#nullable disable
namespace Core.Entities.SQLContext
{
    public partial class PasosSolServicioConexion : BaseEntity
    {
        public PasosSolServicioConexion()
        {
            Etapa = 1;
            FechaRegistroUpdate = DateTime.Now;
            FechaRegistro = DateTime.Now;
        }
        public int CodSolServicioConexion { get; set; }
        public int CodEstado { get; set; }
        public bool? Estado { get; set; }
        public int Etapa { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }

        public virtual SolServicioConexion CodSolServicioConexionNavigation { get; set; }
    }
}
