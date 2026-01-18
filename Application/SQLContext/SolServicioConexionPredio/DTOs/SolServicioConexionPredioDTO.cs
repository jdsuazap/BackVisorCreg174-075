namespace Application.SQLContext.SolServicioConexionPredio.DTOs
{
    using Application.Oracle.SolServicioConexion.DTOs;

    public class SolServicioConexionPredioDTO
    {
        public int Id { get; set; }
        public int CodSolServicioConexion { get; set; }
        public int CodTipoZona { get; set; }
        public string IdentificacionCliente { get; set; } = null!;
        public string CodMunicipio { get; set; } = null!;
        public string CodDepartamento { get; set; } = null!;
        public string Localidad { get; set; } = null!;
        public string DireccionPredio { get; set; } = null!;
        public string UbicacionLong { get; set; } = null!;
        public string UbicacionLat { get; set; } = null!;
        public string UbicacionH { get; set; } = null!;
        public string DescripcionAccesoPredio { get; set; } = null!;
        public int CodTipoConstruccion { get; set; }
        public string? MatriculaInmobiliaria { get; set; }
        public string CodUser { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; } = null!;
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; } = null!;
        public string InfoUpdate { get; set; } = null!;

        public virtual SolServicioConexionDTO IdSolServicioConexionPredioNavigation { get; set; }
    }
}
