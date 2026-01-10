using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class CregDepartamento
    {
        public CregDepartamento()
        {
            Creg174Autogens = new HashSet<Creg174Autogen>();
        }

        public string Id { get; set; } = null!;
        public string CodigoDane { get; set; } = null!;
        public string NombreDepartamento { get; set; } = null!;
        public string Abreviatura { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual ICollection<Creg174Autogen> Creg174Autogens { get; set; }
    }
}
