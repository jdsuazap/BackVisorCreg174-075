namespace Application.Oracle.TipoPersona.DTOs
{
    using Core.Entities.Oracle;

    public class TipoPersonaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Creg075Solicitante> Creg075Solicitante { get; set; }
    }
}
