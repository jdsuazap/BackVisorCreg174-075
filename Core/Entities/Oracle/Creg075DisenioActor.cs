using Core.Enumerations;
using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075DisenioActor
    {
        public Creg075DisenioActor()
        {
            TipoActor = TipoActorDisenioEnum.Propietario;
        }

        public int Id { get; set; }
        public long Cod075Disenio { get; set; }
        public virtual Creg075Disenio Creg075Disenio { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Firma { get; set; }
        public string Cedula { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;       
        public bool? Estado { get; set; }
        public TipoActorDisenioEnum TipoActor { get; set; }

    }
}
