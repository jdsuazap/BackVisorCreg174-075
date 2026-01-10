using Core.Entities.SQLContext;

namespace Core.CustomEntities.SQLContext
{
    public class ListadoSolConexionAutogen
    {
        public int Estado { get; set; }
        public string NombreEstado { get; set; } = null!;
        public List<SolConexionAutogen> Solicitudes { get; set; } = null!;
    }
}
