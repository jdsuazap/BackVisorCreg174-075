using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class CregTipoIdentificacion
    {
        public CregTipoIdentificacion()
        {
            Creg075Solicitantes = new HashSet<Creg075Solicitante>();
            Creg075Suscriptors = new HashSet<Creg075Suscriptor>();
            Creg174Autogens = new HashSet<Creg174Autogen>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Abreviatura { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual ICollection<Creg075Solicitante> Creg075Solicitantes { get; set; }
        public virtual ICollection<Creg075Suscriptor> Creg075Suscriptors { get; set; }
        public virtual ICollection<Creg174Autogen> Creg174Autogens { get; set; }
    }
}
