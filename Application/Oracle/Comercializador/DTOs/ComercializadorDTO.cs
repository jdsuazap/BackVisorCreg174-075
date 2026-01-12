namespace Application.Oracle.Comercializador.DTOs
{
    public class ComercializadorDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        //public virtual ICollection<SolConexionAutogen> SolConexionAutogens { get; set; }
    }
}
