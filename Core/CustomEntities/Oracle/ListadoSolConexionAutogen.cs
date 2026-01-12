namespace Core.CustomEntities.Oracle
{
    using Core.Entities.Oracle;
    public class ListadoSolConexionAutogen
    {
        public int Estado { get; set; }
        public string NombreEstado { get; set; } = null!;
        public List<Creg174Autogen> Solicitudes { get; set; } = null!;
    }
}
