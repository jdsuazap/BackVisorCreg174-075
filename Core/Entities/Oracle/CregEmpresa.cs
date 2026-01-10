using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class CregEmpresa
    {
        public CregEmpresa()
        {
            Creg174Autogens = new HashSet<Creg174Autogen>();
        }

        public int Id { get; set; }
        public string Nit { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? NombreGnr { get; set; }
        public string Direccion { get; set; } = null!;
        public string? Ciudad { get; set; }
        public string Telefono { get; set; } = null!;
        public string Abreviatura { get; set; } = null!;
        public string TrbCodTrabRepLegal { get; set; } = null!;
        public decimal Tope { get; set; }
        public bool? IsBimestralApot { get; set; }
        public string CuentaApot { get; set; } = null!;
        public string? TipoDocAltApot { get; set; }
        public string? CodArchivo { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Creg174Autogen> Creg174Autogens { get; set; }
    }
}
