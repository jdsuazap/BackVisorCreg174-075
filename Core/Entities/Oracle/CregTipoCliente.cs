namespace Core.Entities.Oracle
{
    public partial class CregTipoCliente
    {
        public CregTipoCliente()
        {
            Creg174Autogens = new HashSet<Creg174Autogen>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual ICollection<Creg174Autogen> Creg174Autogens { get; set; }
    }
}
