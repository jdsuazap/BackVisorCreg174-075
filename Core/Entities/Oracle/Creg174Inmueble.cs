using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg174Inmueble
    {
        public int Id { get; set; }
        public int Cod174Autogen { get; set; }
        public string Direccion { get; set; } = null!;
        public string Municipio { get; set; } = null!;
        public string? Corregimiento { get; set; }
        public string? Vereda { get; set; }
        public string? UbicacionGeowgs { get; set; }
        public string? NumeroPosteTransformador { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual Creg174Autogen Cod174AutogenNavigation { get; set; } = null!;
    }
}
