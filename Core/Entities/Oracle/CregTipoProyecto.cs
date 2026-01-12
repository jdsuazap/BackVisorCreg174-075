namespace Core.Entities.Oracle
{
    public partial class CregTipoProyecto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
