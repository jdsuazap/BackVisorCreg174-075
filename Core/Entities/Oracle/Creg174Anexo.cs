using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg174Anexo
    {
        public int Id { get; set; }
        public int Cod174Autogen { get; set; }
        public int CodDocumentosXformulario { get; set; }
        public string NameDocument { get; set; } = null!;
        public string ExtDocument { get; set; } = null!;
        public int SizeDocument { get; set; }
        public string UrlDocument { get; set; } = null!;
        public string UrlRelDocument { get; set; } = null!;
        public string OriginalNamedoCument { get; set; } = null!;
        public int EstadoDocumento { get; set; }
        public DateTime? Expedicion { get; set; }
        public bool? ValidationDocument { get; set; }
        public bool? SendNotification { get; set; }

        public virtual Creg174Autogen Cod174AutogenNavigation { get; set; } = null!;
    }
}
