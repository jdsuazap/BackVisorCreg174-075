namespace Application.Oracle.TipoSolicitudServicio.DTOs
{
    public class TipoSolicitudServicioDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        //public virtual ICollection<SolServicioConexionDetalle> SolServicioConexionDetalles { get; set; }
    }
}
