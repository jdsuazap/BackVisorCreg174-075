using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class CregEstado
    {
        public CregEstado()
        {
            Creg174Autogens = new HashSet<Creg174Autogen>();
        }

        public int Id { get; set; }
        public int CodTipoEstado { get; set; }
        public int? CodEtapa { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool? Estado { get; set; }
        public int? Homologacion { get; set; }

        public virtual ICollection<Creg174Autogen> Creg174Autogens { get; set; }
    }
}
