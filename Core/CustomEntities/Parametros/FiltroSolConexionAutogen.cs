namespace Core.CustomEntities.Parametros
{
    public class FiltroSolConexionAutogen
    {
        public int Estado { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public string? NumeroRadicado { get; set; }
        public int CuentaCliente { get; set; }
        public int CodUsuario { get; set; }
        public int TipoGeneracion { get; set; }
        public decimal CapacidadNominal { get; set; }
        public decimal PotenciaMaximaDeclarada { get; set; }
        public string? Departamento { get; set; }
        public string? Municipio { get; set; }
        public int Empresa { get; set; }
    }
}
