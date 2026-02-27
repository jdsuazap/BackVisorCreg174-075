using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075ReciboTecnicoProy
    {
        public int Id { get; set; }
        public int CodTipoProyecto { get; set; }
        public int Cod075ReciboTecnico { get; set; }
        public decimal Etapa { get; set; }
        public bool? Estado { get; set; }

        public virtual Creg075ReciboTecnico Creg075ReciboTecnico { get; set; }

        public virtual CregTipoProyecto CregTipoProyecto { get; set; }


    }
}
