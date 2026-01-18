namespace Application.Oracle.TipoConstruccion.DTOs
{
    using Application.Oracle.SolServicioConexion.DTOs;
    using Core.Entities.Oracle;

    public class TipoConstruccionDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Creg075Solicitante> SolServicioConexionDatosSolicitantes { get; set; }
    }
}
