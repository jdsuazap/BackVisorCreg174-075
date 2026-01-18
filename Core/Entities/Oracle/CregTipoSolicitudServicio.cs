using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class CregTipoSolicitudServicio
    {
        public CregTipoSolicitudServicio()
        {
            Creg075Detalles = new HashSet<Creg075Detalle>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<Creg075Detalle> Creg075Detalles { get; set; }
    }
}
