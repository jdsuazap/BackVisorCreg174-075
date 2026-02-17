namespace Core.Entities.Oracle
{
    public partial class CregTipoCliente
    {
        public CregTipoCliente()
        {
            Creg174Autogens = new HashSet<Creg174Autogen>();
            Creg075FactibilidadDetCuen = new HashSet<Creg075FactibilidadDetCuen>();
            Creg075ServicioConexion = new HashSet<Creg075ServicioConexion>();
            Creg075DetallesCuentas = new HashSet<Creg075DetallesCuenta>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual ICollection<Creg174Autogen> Creg174Autogens { get; set; }
        public virtual ICollection<Creg075FactibilidadDetCuen> Creg075FactibilidadDetCuen { get; set; }
        public virtual ICollection<Creg075ServicioConexion> Creg075ServicioConexion { get; set; }
        public virtual ICollection<Creg075DetallesCuenta> Creg075DetallesCuentas { get; set; }
    }
}
