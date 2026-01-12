namespace Core.CustomEntities.Oracle
{
    using Core.Entities.SQLContext;
    public class ListadoSolServicioConexion
    {
        public int Estado { get; set; }
        public string NombreEstado { get; set; } = null!;
        public List<SolServicioConexion> Solicitudes { get; set; } = null!;
    }
}
