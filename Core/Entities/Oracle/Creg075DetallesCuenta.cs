using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075DetallesCuenta
    {
        public int Id { get; set; }
        public int Cod075Conexion { get; set; }
        public int CodTipoCarga { get; set; }
        public int CodTipoClaseCarga { get; set; }
        public decimal ValorCarga { get; set; }

        public virtual Creg075ServicioConexion Cod075ConexionNavigation { get; set; } = null!;
        public virtual CregTipoClaseCarga CodTipoClaseCargaNavigation { get; set; } = null!;
    }
}
