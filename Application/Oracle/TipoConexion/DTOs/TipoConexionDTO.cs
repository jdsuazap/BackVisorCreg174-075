using Core.Entities.Oracle;

namespace Application.Oracle.TipoConexion.DTOs
{
    public class TipoConexionDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Creg075ServicioConexion> Creg075ServicioConexion { get; set; }
    }
}
