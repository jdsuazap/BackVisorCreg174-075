using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class CregTipoConstruccion
    {
        public CregTipoConstruccion()
        {
            Creg075Predios = new HashSet<Creg075Predio>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual ICollection<Creg075Predio> Creg075Predios { get; set; }
    }
}
