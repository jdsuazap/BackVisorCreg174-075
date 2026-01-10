#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class TipoActivo : StringBaseEntity
    {
        public string Descripcion { get; set; }
        public string UrlIconoMapa { get; set; }
        public int? AltoIconoMapa { get; set; }
        public int? AnchoIconoMapa { get; set; }
        public bool? Estado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }
    }
}
