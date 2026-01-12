namespace Application.Oracle.PersonaAutorizaRecibo.DTOs
{
    public class PersonaAutorizaReciboDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        //public virtual ICollection<SolReciboTecnico> SolReciboTecnicos { get; set; }
    }
}
