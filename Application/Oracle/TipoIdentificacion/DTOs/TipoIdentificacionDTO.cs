namespace Application.Oracle.TipoIdentificacion.DTOs
{
    using Core.Entities.Oracle;

    public class TipoIdentificacionDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Creg174Autogen> Creg174Autogen { get; set; }
        public virtual ICollection<Creg075Solicitante> Creg075Solicitante { get; set; }
    }
}
