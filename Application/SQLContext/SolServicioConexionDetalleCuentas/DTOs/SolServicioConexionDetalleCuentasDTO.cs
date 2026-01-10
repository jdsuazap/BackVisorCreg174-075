namespace Application.SQLContext.SolServicioConexionDetalleCuentas.DTOs
{
    using Application.SQLContext.SolServicioConexion.DTOs;

    public class SolServicioConexionDetalleCuentasDTO
    {
        public int Id { get; set; }
        public int CodSolServicioConexion { get; set; }
        public int CodTipoCarga { get; set; }
        public int CodTipoClaseCarga { get; set; }
        public decimal ValorCarga { get; set; }
        public string CodUser { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; } = null!;
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; } = null!;
        public string InfoUpdate { get; set; } = null!;

        public virtual SolServicioConexionDTO CodSolServicioConexionNavigation { get; set; } = null!;
    }
}
