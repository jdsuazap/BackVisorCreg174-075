using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075FactibilidadDetCuen
    {
        public Creg075FactibilidadDetCuen()
        {
            Estado = true;
        }

        public int Id { get; set; }
        public long Cod075Factibilidad { get; set; }
        public int CodTipoCarga { get; set; }
        public int CodTipoClaseCarga { get; set; }
        public string ValorCarga { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual CregTipoCliente CregTipoCliente { get; set; }

        public virtual CregTipoClaseCarga CregTipoClaseCarga { get; set; }

        public virtual Creg075Factibilidad Creg075Factibilidad { get; set; } = null!;
    }
}
