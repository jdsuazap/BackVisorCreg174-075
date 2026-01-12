namespace Application.Oracle.TipoIdentificacion.DTOs
{
    public class TipoIdentificacionDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public bool? Estado { get; set; }

        //public virtual ICollection<SolConexionAutogen> SolConexionAutogens { get; set; }
        //public virtual ICollection<SolServicioConexionDatosSolicitante> SolServicioConexionDatosSolicitantes { get; set; }
    }
}
