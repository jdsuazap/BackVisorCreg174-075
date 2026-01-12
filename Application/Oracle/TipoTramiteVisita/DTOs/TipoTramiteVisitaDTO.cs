namespace Application.Oracle.TipoTramiteVisita.DTOs
{
    public class TipoTramiteVisitaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }

        //public virtual ICollection<SolConexionAutogenXvisita> SolConexionAutogenXvisita { get; set; }
    }
}
