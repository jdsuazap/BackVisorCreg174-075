using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075FactibilidadObs
    {
        public decimal Id { get; set; }
        public long Cod075Factibilidad { get; set; }
        public string NombreProyecto { get; set; } = null!;
        public string GestionadoPor { get; set; } = null!;
        public string Observacion { get; set; } = null!;
        public bool? Estado { get; set; }
        public virtual Creg075Factibilidad Creg075Factibilidad { get; set; } = null!;

    }
}
