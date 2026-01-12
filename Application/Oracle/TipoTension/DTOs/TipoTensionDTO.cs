namespace Application.Oracle.TipoTension.DTOs
{
    public class TipoTensionDTO
    {
        public int Id { get; set; }
        public int Nivel { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        //public virtual ICollection<SolServicioConexionDetalle> SolServicioConexionDetalles { get; set; }
    }
}
