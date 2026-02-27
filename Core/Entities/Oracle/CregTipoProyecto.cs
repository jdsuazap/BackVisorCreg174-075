namespace Core.Entities.Oracle
{
    public partial class CregTipoProyecto
    {
        public CregTipoProyecto()
        {
            Creg075FactibilidadProye = new HashSet<Creg075FactibilidadProye>();
            Creg075ReciboTecnicoProy = new HashSet<Creg075ReciboTecnicoProy>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<Creg075FactibilidadProye> Creg075FactibilidadProye { get; set; }
        public virtual ICollection<Creg075ReciboTecnicoProy> Creg075ReciboTecnicoProy { get; set; }
    }
}
