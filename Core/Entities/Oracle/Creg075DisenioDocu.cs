using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075DisenioDocu
    {
        public Creg075DisenioDocu()
        {
            Estado = true;
        }

        public decimal Id { get; set; }
        public int Cod075Conexion { get; set; }
        public long Cod075Disenio { get; set; }
        public int CodDocumentos { get; set; }
        public bool? Valor { get; set; }
        public bool? Estado { get; set; }
        public virtual Creg075ServicioConexion Creg075ServicioConexion { get; set; }
        public virtual Creg075Disenio Creg075Disenio { get; set; }
        public virtual CregDocumentosFormulario CregDocumentosFormulario { get; set; }

    }
}
