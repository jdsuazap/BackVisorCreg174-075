namespace Application.Oracle.TipoCompletitud.DTOs
{
    public class TipoCompletitudDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        //public virtual ICollection<SolReciboTecnico> SolReciboTecnicos { get; set; }
    }
}
