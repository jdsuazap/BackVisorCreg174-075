namespace Application.Oracle.TipoTramiteVisita.DTOs
{
    public class TipoTramiteVisitaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        //public virtual ICollection<SolConexionAutogenXvisita> SolConexionAutogenXvisita { get; set; }
    }
}
