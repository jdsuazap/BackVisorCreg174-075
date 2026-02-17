using Core.Entities.Oracle;

namespace Application.Oracle.TipoSolicitudServicio.DTOs
{
    public class TipoSolicitudServicioDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Creg075Detalle> Creg075Detalle { get; set; }
    }
}
