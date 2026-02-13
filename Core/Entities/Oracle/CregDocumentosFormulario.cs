using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class CregDocumentosFormulario
    {
        public CregDocumentosFormulario()
        {
            Creg075Anexos = new HashSet<Creg075Anexo>();
            Creg174Anexos = new HashSet<Creg174Anexo>();
            Creg075DisenioAnexos = new HashSet<Creg075DisenioAnexo>();
            Creg075FactibilidadAnexos = new HashSet<Creg075FactibilidadAnexo>();
            Creg075FactibilidadDocu = new HashSet<Creg075FactibilidadDocu>();
        }

        public int Id { get; set; }
        public string NombreDocumento { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool? Estado { get; set; }
        public bool? Requiered { get; set; }
        public long Limitload { get; set; }
        public bool? Vigencia { get; set; }
        public int VigenciaMaxima { get; set; }
        public bool? IsCampo { get; set; }
        public decimal? CodFormulario { get; set; }

        public virtual ICollection<Creg075Anexo> Creg075Anexos { get; set; }
        public virtual ICollection<Creg174Anexo> Creg174Anexos { get; set; }
        public virtual ICollection<Creg075DisenioAnexo> Creg075DisenioAnexos { get; set; }
        public virtual ICollection<Creg075FactibilidadAnexo> Creg075FactibilidadAnexos { get; set; }
        public virtual ICollection<Creg075FactibilidadDocu> Creg075FactibilidadDocu { get; set; }

    }
}
