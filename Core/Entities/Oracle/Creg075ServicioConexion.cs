using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075ServicioConexion
    {
        public Creg075ServicioConexion()
        {
            Creg075Anexos = new HashSet<Creg075Anexo>();
            Creg075Detalles = new Creg075Detalle();
            Creg075DetallesCuentas = new HashSet<Creg075DetallesCuenta>();
            Creg075Disenios = new HashSet<Creg075Disenio>();
            Creg075DisenioAnexos = new HashSet<Creg075DisenioAnexo>();
            Creg075Factibilidads = new HashSet<Creg075Factibilidad>();
            Creg075Predios = new Creg075Predio();
            Creg075Solicitantes = new HashSet<Creg075Solicitante>();
            Creg075Pasos = new HashSet<Creg075Pasos>();
            Creg075ReciboTecnicos = new HashSet<Creg075ReciboTecnico>();

        }

        public int Id { get; set; }
        public int? Empresa { get; set; }
        public string NumeroRadicado { get; set; } = null!;
        public DateTime FechaSolicitud { get; set; }
        public int CodTipoConexion { get; set; }
        public int CodTipoUso { get; set; }
        public string? Otrotipouso { get; set; }
        public int? CodEstrato { get; set; }
        public int? CodActividadEconomica { get; set; }
        public bool ExisteRed { get; set; }
        public string DistanciaRed { get; set; } = null!;
        public string Transformador { get; set; } = null!;
        public string Nodo { get; set; } = null!;
        public string Circuito { get; set; } = null!;
        public string? ObservacionesSolicitante { get; set; }
        public bool? DocumentacionCompleta { get; set; }
        public bool? ObraConforme { get; set; }
        public bool? ReciboTecnico { get; set; }
        public bool? NormalizacionVisita { get; set; }
        public bool? FactibilidadApoyo { get; set; }
        public bool? Normalizacion { get; set; }
        public bool? Anulacion { get; set; }
        public bool? DesistirSolicitud { get; set; }
        public bool? Factibilidad { get; set; }
        public int CodEtapa { get; set; }
        public int CodEstado { get; set; }

        public virtual CregActividadEconomica? CodActividadEconomicaNavigation { get; set; }
        public virtual CregEstado CodEstadoNavigation { get; set; } = null!;
        public virtual CregEstratoSocioeconomico? CodEstratoNavigation { get; set; }
        public virtual CregEtapa CodEtapaNavigation { get; set; } = null!;
        public virtual CregTipoConexion CodTipoConexionNavigation { get; set; } = null!;
        public virtual CregTipoCliente CodTipoUsoNavigation { get; set; }

        public virtual ICollection<Creg075Anexo> Creg075Anexos { get; set; }
        public virtual Creg075Detalle Creg075Detalles { get; set; }
        public virtual ICollection<Creg075DetallesCuenta> Creg075DetallesCuentas { get; set; }
        public virtual ICollection<Creg075Disenio> Creg075Disenios { get; set; }
        public virtual ICollection<Creg075DisenioAnexo> Creg075DisenioAnexos { get; set; }
        public virtual ICollection<Creg075Factibilidad> Creg075Factibilidads { get; set; }
        public virtual Creg075Predio? Creg075Predios { get; set; }
        public virtual ICollection<Creg075Solicitante> Creg075Solicitantes { get; set; }
        public virtual Creg075Suscriptor? Creg075Suscriptors { get; set; }
        public virtual ICollection<Creg075Pasos> Creg075Pasos { get; set; }
        public virtual ICollection<Creg075ReciboTecnico> Creg075ReciboTecnicos { get; set; }
        public virtual ICollection<Creg075DisenioDocu> Creg075DisenioDocu { get; set; }


    }
}
