using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.SQLContext
{
    public partial class TipoEtapa : BaseEntity
    {
        public TipoEtapa()
        {
        }

        /// <summary>
        /// Descripción del tipo de etapa
        /// </summary>
        public string Descripcion { get; set; } = null!;
        /// <summary>
        /// Estado del registro
        /// </summary>
        public bool? Estado { get; set; }
        public string CodUser { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; } = null!;
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; } = null!;
        public string InfoUpdate { get; set; } = null!;
    }
}
