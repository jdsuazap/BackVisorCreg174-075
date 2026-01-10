namespace Application.SQLContext.TipoIdentificacion.DTOs
{
    public class TipoIdentificacionDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public bool? Estado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }

        //public virtual ICollection<SolConexionAutogen> SolConexionAutogens { get; set; }
        //public virtual ICollection<SolServicioConexionDatosSolicitante> SolServicioConexionDatosSolicitantes { get; set; }
    }
}
