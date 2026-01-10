using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg174Tecnologia
    {
        public int Id { get; set; }
        public int Cod174Autogen { get; set; }
        public bool AlmacenamientoEnergia { get; set; }
        public int? CapacidadKw { get; set; }
        public int? CapacidadKwh { get; set; }
        public bool BasadoInversores { get; set; }
        public bool BasadoMaqSincronicas { get; set; }
        public bool BasadoMaqAsincronicas { get; set; }
        public string? OtraTecnologiaBase { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual Creg174Autogen Cod174AutogenNavigation { get; set; } = null!;
    }
}
