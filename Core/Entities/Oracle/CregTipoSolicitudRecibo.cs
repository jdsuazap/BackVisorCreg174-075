using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class CregTipoSolicitudRecibo
    {
        public CregTipoSolicitudRecibo()
        {
            Creg075Factibilidads = new HashSet<Creg075Factibilidad>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<Creg075Factibilidad> Creg075Factibilidads { get; set; }
    }
}
