using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075FactibilidadDocu
    {
        public long Id { get; set; }
        public long Cod075Factibilidad { get; set; }
        public int CodDocumentos { get; set; }
        public bool? Valor { get; set; }
        public bool? Estado { get; set; }

        public virtual Creg075Factibilidad Creg075Factibilidad { get; set; } = null!;

        public virtual CregDocumentosFormulario CregDocumentosFormulario { get; set; }
    }
}
