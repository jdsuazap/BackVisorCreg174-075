using Core.Entities.Oracle;

namespace Application.Oracle.TipoServicio.DTOs
{
    public class TipoServicioDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Creg075Detalle> Creg075Detalle { get; set; }
    }
}
