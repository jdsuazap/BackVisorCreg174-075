namespace Application.Oracle.TipoZona.DTOs
{
    public class TipoZonaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }   

        //public virtual ICollection<SolServicioConexionPredio> SolServicioConexionPredios { get; set; }
    }
}
