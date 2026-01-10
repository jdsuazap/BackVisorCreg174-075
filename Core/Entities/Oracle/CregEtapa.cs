using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class CregEtapa
    {
        public int Id { get; set; }
        public int CodTipoEtapa { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool? Estado { get; set; }
    }
}
