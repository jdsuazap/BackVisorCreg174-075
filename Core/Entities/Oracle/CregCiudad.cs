using Core.Entities.SQLContext;
using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class CregCiudad
    {
        public CregCiudad()
        {
            Creg075Predios = new HashSet<Creg075Predio>();
            Creg075Solicitantes = new HashSet<Creg075Solicitante>();
            Creg075Suscriptors = new HashSet<Creg075Suscriptor>();
            
            Creg174Autogens = new HashSet<Creg174Autogen>();
            Creg174Inmuebles = new HashSet<Creg174Inmueble>();

        }

        public string Id { get; set; } = null!;
        public string CodDepartamento { get; set; } = null!;
        public string NombreCiudad { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual ICollection<Creg075Predio> Creg075Predios { get; set; }
        public virtual ICollection<Creg075Solicitante> Creg075Solicitantes { get; set; }
        public virtual ICollection<Creg075Suscriptor> Creg075Suscriptors { get; set; }


        public virtual ICollection<Creg174Autogen> Creg174Autogens { get; set; }
        public virtual ICollection<Creg174Inmueble> Creg174Inmuebles { get; set; }

    }
}
