using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075Predio
    {
        public int Id { get; set; }
        public int Cod075Conexion { get; set; }
        public int CodZona { get; set; }
        public string IdentificacionCliente { get; set; } = null!;
        public string CodMunicipio { get; set; } = null!;
        public string CodDepartamento { get; set; } = null!;
        public string Localidad { get; set; } = null!;
        public string DireccionPredio { get; set; } = null!;
        public string? UbicacionLong { get; set; }
        public string? UbicacionLat { get; set; }
        public string? UbicacionH { get; set; }
        public string DescripcionPredio { get; set; } = null!;
        public int CodTipoConstruccion { get; set; }
        public string? MatriculaInmobiliaria { get; set; }

        public virtual Creg075ServicioConexion Cod075ConexionNavigation { get; set; } = null!;
        public virtual CregDepartamento CodDepartamentoNavigation { get; set; } = null!;
        public virtual CregCiudad CodMunicipioNavigation { get; set; } = null!;
        public virtual CregTipoConstruccion CodTipoConstruccionNavigation { get; set; } = null!;
        public virtual CregTipoZona CodZonaNavigation { get; set; } = null!;
    }
}
