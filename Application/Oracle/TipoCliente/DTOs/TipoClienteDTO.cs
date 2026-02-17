using Core.Entities.Oracle;

namespace Application.Oracle.TipoCliente.DTOs
{
    public class TipoClienteDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Creg174Autogen> Creg174Autogen { get; set; }
        public virtual ICollection<Creg075DetallesCuenta> Creg075DetallesCuenta { get; set; }
        public virtual ICollection<Creg075ServicioConexion> Creg075ServicioConexion { get; set; }
    }
}
