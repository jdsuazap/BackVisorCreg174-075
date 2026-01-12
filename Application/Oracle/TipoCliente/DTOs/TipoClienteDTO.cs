namespace Application.Oracle.TipoCliente.DTOs
{
    public class TipoClienteDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        //public virtual ICollection<SolConexionAutogen> SolConexionAutogens { get; set; }
        //public virtual ICollection<SolServicioConexionDetalleCuenta> SolServicioConexionDetalleCuenta { get; set; }
        //public virtual ICollection<SolServicioConexion> SolServicioConexions { get; set; }
    }
}
