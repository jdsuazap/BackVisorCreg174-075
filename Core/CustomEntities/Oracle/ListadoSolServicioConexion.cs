namespace Core.CustomEntities.Oracle
{
    using Core.Entities.Oracle;
    public class ListadoSolServicioConexion
    {
        public int Estado { get; set; }
        public string NombreEstado { get; set; } = null!;
        public List<Creg075ServicioConexion> Solicitudes { get; set; } = null!;
    }
}
