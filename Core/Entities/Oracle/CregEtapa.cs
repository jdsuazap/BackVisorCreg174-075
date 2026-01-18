using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class CregEtapa
    {
        public CregEtapa()
        {
            Creg075ServicioConexions = new HashSet<Creg075ServicioConexion>();
        }

        public int Id { get; set; }
        public int CodTipoEtapa { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual ICollection<Creg075ServicioConexion> Creg075ServicioConexions { get; set; }
    }
}
