namespace Application.Oracle.TipoZona.DTOs
{
    using Core.Entities.Oracle;

    public class TipoZonaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }   

        public virtual ICollection<Creg075Predio> Creg075Predio { get; set; }
    }
}
