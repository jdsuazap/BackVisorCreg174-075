using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075Detalle
    {
        public int Id { get; set; }
        public int Cod075Conexion { get; set; }
        public string NombreProyecto { get; set; } = null!;
        public int CodTipoSolicitud { get; set; }
        public string? NumeroSolicitud { get; set; }
        public DateTime? Vigencia { get; set; }
        public int? CodTipoSSolicitud { get; set; }
        public string? OtrotipoSSolicitud { get; set; }
        public decimal CargaExistente { get; set; }
        public decimal CargaMaximaRequerida { get; set; }
        public int CodTension { get; set; }
        public bool SistemaGeneracion { get; set; }
        public DateTime? FechaOperacion { get; set; }

        public virtual Creg075ServicioConexion Cod075ConexionNavigation { get; set; } = null!;
        public virtual CregTipoTension CodTensionNavigation { get; set; } = null!;
        public virtual CregTipoSolicitudServicio CodTipoSolicitudNavigation { get; set; } = null!;
    }
}
