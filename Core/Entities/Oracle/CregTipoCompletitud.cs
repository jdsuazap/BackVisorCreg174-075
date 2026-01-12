namespace Core.Entities.Oracle
{
    public partial class CregTipoCompletitud
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
