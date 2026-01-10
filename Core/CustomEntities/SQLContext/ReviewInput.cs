namespace Core.CustomEntities.SQLContext
{
    using Core.Entities.SQLContext;
    using Core.Enumerations;


    public class ReviewInput
    {
        public SolServicioConexionReview Entity { get; set; }
        public EstadosEnum ApprovedStatus { get; set; }
        public EstadosEnum RejectedStatus { get; set; }
        public string ApprovedMessage { get; set; }
        public string RejectedMessage { get; set; }
        public string EmailMessage { get; set; }
        public string AnexosPath { get; set; }
        public List<CorreosEnum> CorreoEnum { get; set; } = new List<CorreosEnum>();
        public CuerpoCorreoEnum CuerpoCorreo { get; set; } = CuerpoCorreoEnum.Creg075_Solicitud_Actualizacion_Estado_Solicitud;
        public bool HasCuerpoCorreo { get; set; }
        public bool EnviaCorreo { get; set; } = true;
        public ScheduleMailEnum ScheduleMailType { get; set; } = ScheduleMailEnum.SendWithTemplate;
        public Dictionary<string, string> ParametrosCuerpoCorreo { get; set; } = null;
        public bool OtherMails { get; set; }
        public int? CodPerfil { get; set; }
    }
}
