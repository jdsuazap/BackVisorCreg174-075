namespace Core.Entities.Oracle
{
    public partial class CregDocumentosFormulario
    {
        public int Id { get; set; }
        public string NombreDocumento { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool? Estado { get; set; }
        public bool? Requiered { get; set; }
        public long Limitload { get; set; }
        public bool? Vigencia { get; set; }
        public int VigenciaMaxima { get; set; }
        public bool? IsCampo { get; set; }
        public decimal? CodFormulario { get; set; }
    }
}
