using System.Text;

namespace Core.Tools
{
    public static class DapperSplitOn
    {
        /// <summary>
        /// Método para construir Split On de manera dinamica
        /// </summary>
        /// <param name="relationatedEntities">arreglo de tipos de entidades</param>
        /// <returns></returns>
        public static string ConstruirSplitOn(Type[] relationatedEntities)
        {
            StringBuilder stringBuilder = new();

            var entitiesToProcess = relationatedEntities.Skip(1); // Excluir el primer elemento (SplitOn se construye a partir del segundo modelo)

            var propertiesToInclude = entitiesToProcess
                    .SelectMany(entityType => entityType.GetProperties())
                    .Where(property => property.Name.Contains("Id") && !property.Name.Equals("Id"))
                    .Select(property => property.Name);

            // Eliminar la coma y el espacio al final de la cadena
            string result = string.Join(", ", propertiesToInclude);
            return result;
        }
    }
}
