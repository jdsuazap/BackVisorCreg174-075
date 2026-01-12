namespace Application.Oracle.ActividadEconomica.DTOs
{
    //using Application.SQLContext.SolServicioConexion.DTOs;

    public class ActividadEconomicaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        //public virtual ICollection<SolServicioConexionDTO> SolServicioConexions { get; set; }
    }
}
