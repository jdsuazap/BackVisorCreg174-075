namespace Core.CustomEntities.Parametros
{
    public class FiltroSolServicioConexion
    {
        public int Estado { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public string? NumeroRadicado { get; set; }
        public int CodUsuario { get; set; }
        public int TipoConexion { get; set; }
        public string? Departamento { get; set; }
        public string? Municipio { get; set; }
        public int Empresa { get; set; }
    }
}
