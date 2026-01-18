using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class CregEstado
    {
        public CregEstado()
        {
            Creg075ServicioConexions = new HashSet<Creg075ServicioConexion>();
            Creg174Autogens = new HashSet<Creg174Autogen>();
            Creg174Pasos = new HashSet<Creg174Pasos>();
        }

        public int Id { get; set; }
        public int CodTipoEstado { get; set; }
        public int? CodEtapa { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool? Estado { get; set; }
        public int? Homologacion { get; set; }

        public virtual ICollection<Creg075ServicioConexion> Creg075ServicioConexions { get; set; }
        public virtual ICollection<Creg174Autogen> Creg174Autogens { get; set; }
        public virtual ICollection<Creg174Pasos> Creg174Pasos { get; set; }
    }
}
