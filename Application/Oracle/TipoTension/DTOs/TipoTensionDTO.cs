namespace Application.Oracle.TipoTension.DTOs
{
    using Core.Entities.Oracle;
    public class TipoTensionDTO
    {
        public int Id { get; set; }
        public int Nivel { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Creg075Detalle> Creg075Detalle { get; set; }
    }
}
