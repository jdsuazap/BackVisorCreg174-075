namespace Application.Oracle.TipoServicio.DTOs
{
    public class TipoServicioDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        //public virtual ICollection<SolServicioConexionDetalle> SolServicioConexionDetalles { get; set; }
    }
}
