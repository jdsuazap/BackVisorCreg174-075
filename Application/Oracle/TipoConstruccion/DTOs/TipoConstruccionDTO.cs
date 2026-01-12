namespace Application.Oracle.TipoConstruccion.DTOs
{
    using Application.SQLContext.SolServicioConexion.DTOs;
    using System;

    public class TipoConstruccionDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        //public virtual ICollection<SolServicioConexionDatosSolicitante> SolServicioConexionDatosSolicitantes { get; set; }
    }
}
