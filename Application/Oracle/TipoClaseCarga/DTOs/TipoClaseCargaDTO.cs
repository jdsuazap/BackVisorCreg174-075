namespace Application.Oracle.TipoClaseCarga.DTOs
{
    using Core.Entities.Oracle;

    public class TipoClaseCargaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Creg075DetallesCuenta> Creg075DetallesCuenta { get; set; }
    }
}
