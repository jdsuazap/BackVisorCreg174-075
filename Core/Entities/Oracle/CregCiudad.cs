namespace Core.Entities.Oracle
{
    public partial class CregCiudad : StringBaseEntity
    {
        public CregCiudad()
        {
            Creg174Autogens = new HashSet<Creg174Autogen>();
        }

        public string CodDepartamento { get; set; } = null!;
        public string NombreCiudad { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual ICollection<Creg174Autogen> Creg174Autogens { get; set; }
    }
}
