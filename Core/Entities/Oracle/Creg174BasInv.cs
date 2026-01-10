using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg174BasInv
    {
        public int Id { get; set; }
        public int Cod174Autogen { get; set; }
        public decimal? PotenciaPanel { get; set; }
        public decimal? NumPaneles { get; set; }
        public bool? PoseeRele { get; set; }
        public decimal? CapacidadDc { get; set; }
        public decimal? PotTotalAc { get; set; }
        public decimal? VoltSalInv { get; set; }
        public decimal? VoltEntInv { get; set; }
        public decimal? NumFases { get; set; }
        public decimal? NumInversores { get; set; }
        public bool? PoseePpc { get; set; }
        public string? FabricanteInv { get; set; }
        public string? ModeloInv { get; set; }
        public bool? CumpleUl1741 { get; set; }
        public byte? AnioUl1741 { get; set; }
        public bool? CumpleIec61727 { get; set; }
        public byte? AnioIec61727 { get; set; }
        public decimal? TrafoPotNominal { get; set; }
        public decimal? TrafoImpedancia { get; set; }
        public string? TrafoGrupoConex { get; set; }
        public string? DescripcionElementos { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual Creg174Autogen Cod174AutogenNavigation { get; set; } = null!;
    }
}
