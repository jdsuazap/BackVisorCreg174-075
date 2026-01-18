using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class CregTipoClaseCarga
    {
        public CregTipoClaseCarga()
        {
            Creg075DetallesCuenta = new HashSet<Creg075DetallesCuenta>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<Creg075DetallesCuenta> Creg075DetallesCuenta { get; set; }
    }
}
