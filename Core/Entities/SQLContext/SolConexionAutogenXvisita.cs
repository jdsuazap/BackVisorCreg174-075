#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class SolConexionAutogenXvisita : BaseEntity
    {
        public SolConexionAutogenXvisita()
        {
        }

        public int CodSolConexionAutogen { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreAtiendeVisita { get; set; }
        public decimal Telefono { get; set; }
        public string Email { get; set; }
        public int EquiposCumplen { get; set; }
        public int? CodTipoTramiteVisita { get; set; }
        public string Observaciones { get; set; }
        public bool? EsAprobado { get; set; }
        public int Estado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }

        public virtual SolConexionAutogen CodSolConexionAutogenNavigation { get; set; }
        public virtual TipoTramiteVisita CodTipoTramiteVisitaNavigation { get; set; }
    }
}
