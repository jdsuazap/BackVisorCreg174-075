using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class CregTipoPersona
    {
        public CregTipoPersona()
        {
            Creg075Solicitantes = new HashSet<Creg075Solicitante>();
            Creg075Suscriptors = new HashSet<Creg075Suscriptor>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<Creg075Solicitante> Creg075Solicitantes { get; set; }
        public virtual ICollection<Creg075Suscriptor> Creg075Suscriptors { get; set; }
    }
}
