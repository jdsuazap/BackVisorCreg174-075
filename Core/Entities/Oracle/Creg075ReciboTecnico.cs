using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075ReciboTecnico
    {
        public Creg075ReciboTecnico()
        {
            Etapa = 1;
            Creg075ReciboTecnicoAnexo = new HashSet<Creg075ReciboTecnicoAnexo>();
            //SolServicioConexionTipoProyectoPorReciboTecnicos = new HashSet<SolServicioConexionTipoProyectoPorReciboTecnico>();
        }

        public int Id { get; set; }
        public int Cod075Conexion { get; set; }
        public int CodTipoCompletitud { get; set; }
        public int CodTipoSolicitud { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string NombreProyecto { get; set; } = null!;
        public string OficinaRadicacion { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Comercializador { get; set; }
        public string? NumeroMatricula { get; set; }
        public string? ClienteCargoMedidor { get; set; }
        public int CodPersonaAutorizacion { get; set; }
        public int? EtapaProyecto { get; set; }
        public int Etapa { get; set; }
        public string NombreConstructora { get; set; } = null!;
        public string NitConstructora { get; set; } = null!;
        public string NombreIngeniero { get; set; } = null!;
        public string FirmaIngeniero { get; set; } = null!;
        public string MatriculaProfesional { get; set; } = null!;
        public string TelefonoIngeniero { get; set; } = null!;
        public string EmailIngeniero { get; set; } = null!;
        public string CedulaIngeniero { get; set; } = null!;
        public string NombrePropietario { get; set; } = null!;
        public string FirmaPropietario { get; set; } = null!;
        public string TelefonoPropietario { get; set; } = null!;
        public string EmailPropietario { get; set; } = null!;
        public string CedulaPropietario { get; set; } = null!;
        public string? Observaciones { get; set; }
        public bool? Estado { get; set; }

        public virtual CregPersonaAutoriza CregPersonaAutoriza { get; set; }
        public virtual CregTipoCompletitud CregTipoCompletitud { get; set; }
        public virtual CregTipoSolicitudRecibo CregTipoSolicitudRecibo { get; set; }
        public Creg075ServicioConexion Creg075ServicioConexion { get; set; }
        public ICollection<Creg075ReciboTecnicoAnexo> Creg075ReciboTecnicoAnexo { get; set; }
        //public virtual ICollection<SolServicioConexionTipoProyectoPorReciboTecnico> SolServicioConexionTipoProyectoPorReciboTecnicos { get; set; }
    }
}
