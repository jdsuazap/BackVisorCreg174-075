using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg174NoBasInv
    {
        public int Id { get; set; }
        public int Cod174Autogen { get; set; }
        public string? FabricanteGenerador { get; set; }
        public string? ModeloGenerador { get; set; }
        public int? VoltajeGenerador { get; set; }
        public decimal? PotenciaNominal { get; set; }
        public decimal? FactorPotencia { get; set; }
        public int? NumeroFases { get; set; }
        public decimal? TransfoPotNominal { get; set; }
        public decimal? TransfoImpedancia { get; set; }
        public string? TransfoGrupoConex { get; set; }
        public string? DescripcionElementos { get; set; }
        public bool? CumpleIeee1547 { get; set; }
        public byte? AnioIeee1547 { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual Creg174Autogen Cod174AutogenNavigation { get; set; } = null!;
    }
}
