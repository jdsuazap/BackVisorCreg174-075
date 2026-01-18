using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075Solicitante
    {
        public int Id { get; set; }
        public int Cod075Conexion { get; set; }
        public string Nombre { get; set; } = null!;
        public int CodTipoPersona { get; set; }
        public int CodTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string CodMunicipio { get; set; } = null!;
        public string CodDepartamento { get; set; } = null!;
        public int Celular { get; set; }
        public int? Telefono { get; set; }
        public string Email { get; set; } = null!;
        public bool AutorizacionNotifEmail { get; set; }
        public bool? EsSolicitantePropietario { get; set; }

        public virtual Creg075ServicioConexion Cod075ConexionNavigation { get; set; } = null!;
        public virtual CregDepartamento CodDepartamentoNavigation { get; set; } = null!;
        public virtual CregCiudad CodMunicipioNavigation { get; set; } = null!;
        public virtual CregTipoIdentificacion CodTipoDocumentoNavigation { get; set; } = null!;
        public virtual CregTipoPersona CodTipoPersonaNavigation { get; set; } = null!;
    }
}
