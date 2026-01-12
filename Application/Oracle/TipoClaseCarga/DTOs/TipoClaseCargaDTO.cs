namespace Application.Oracle.TipoClaseCarga.DTOs
{
    public class TipoClaseCargaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        //public virtual ICollection<SolServicioConexionDetalleCuenta> SolServicioConexionDetalleCuenta { get; set; }
    }
}
