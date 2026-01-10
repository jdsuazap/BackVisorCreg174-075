using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg174TecnUtilizada
    {
        public int Id { get; set; }
        public int Cod174Autogen { get; set; }
        public int? CodTipoTecnologia { get; set; }
        public string? OtroTipoTecnologia { get; set; }
        public string? CapacidadKwPorTecnologia { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual Creg174Autogen Cod174AutogenNavigation { get; set; } = null!;
    }
}
