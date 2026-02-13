namespace Application.Oracle.SolServicioConexionDisenio.DTOs
{
    using Core.CustomEntities.Oracle;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public  class SolServicioConexionDisenioPorDocumentoDTO: SolServicioConexionDisenioPorDocumentoCreate
    {
        public long Id { get; set; }
    }
}
