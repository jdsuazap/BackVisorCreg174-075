namespace Application.Oracle.SolServicioConexion.DTOs
{
    public class AnexoBaseDTO
    {
        public int CodSolServicioConexion { get; set; }
        public string NameDocument { get; set; }
        public string ExtDocument { get; set; }
        public int SizeDocument { get; set; }
        public string UrlDocument { get; set; }
        public string UrlRelDocument { get; set; }
        public string OriginalNameDocument { get; set; }
        public int EstadoDocumento { get; set; }
        public DateTime? Expedicion { get; set; }
        public bool ValidationDocument { get; set; }
        public bool SendNotification { get; set; }
        public string Source { get; set; } = string.Empty;
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }
    }
}
