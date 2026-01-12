namespace Core.Entities.Oracle
{
    public partial class Creg174Infoeolica
    {
        public int Id { get; set; }
        public int Cod174Autogen { get; set; }
        public string? FabricanteAerogenerador { get; set; }
        public string? Modelo { get; set; }
        public decimal? VoltajeAc { get; set; }
        public decimal? PotenciaNominal { get; set; }
        public int? NumAerogeneradores { get; set; }
        public decimal? CodTipoAerogenerador { get; set; }
        public string? PoseePpc { get; set; }
        public decimal? TransfoPotnominal { get; set; }
        public decimal? TransfoImpedanciacc { get; set; }
        public string? TransfoGrupoconex { get; set; }
        public string? DescripcionElementos { get; set; }
        public bool? CumpleIeee1547 { get; set; }
        public byte? AnioIeee1547 { get; set; }

        public virtual Creg174Autogen Cod174AutogenNavigation { get; set; } = null!;

    }
}
