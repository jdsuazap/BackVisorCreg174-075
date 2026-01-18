using Core.Entities.Oracle;

namespace Application.Oracle.TipoTecnologia.DTOs
{
    public class TipoTecnologiaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Creg174TecnUtilizada> Creg174TecnUtilizada { get; set; }
    }
}
