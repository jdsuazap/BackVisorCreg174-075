using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075FactibilidadProye
    {
        public decimal Id { get; set; }
        public long Cod075Factibilidad { get; set; }
        public int CodTipoProyecto { get; set; }
        public bool? Estado { get; set; }

        public virtual Creg075Factibilidad Creg075Factibilidad { get; set; } = null!;

        public virtual CregTipoProyecto CregTipoProyecto { get; set; }
    }
}
