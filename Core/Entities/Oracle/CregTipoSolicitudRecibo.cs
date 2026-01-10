using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class CregTipoSolicitudRecibo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
