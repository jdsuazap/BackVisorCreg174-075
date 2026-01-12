namespace Application.Oracle.TipoProyecto.DTOs
{
    public class TipoProyectoDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        //public virtual ICollection<SolReciboTecnico> SolReciboTecnicos { get; set; }
    }
}
