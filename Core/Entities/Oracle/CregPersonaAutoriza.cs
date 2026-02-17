namespace Core.Entities.Oracle
{
    public partial class CregPersonaAutoriza
    {
        public CregPersonaAutoriza()
        {
            Creg075ReciboTecnico = new HashSet<Creg075ReciboTecnico>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<Creg075ReciboTecnico> Creg075ReciboTecnico { get; set; }

    }
}
