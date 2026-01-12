namespace Application.Oracle.EstratoSocioeconomico.DTOs
{
    public class EstratoSocioeconomicoDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        //public virtual ICollection<SolConexionAutogen> SolConexionAutogens { get; set; }
        //public virtual ICollection<SolServicioConexion> SolServicioConexions { get; set; }
    }
}
