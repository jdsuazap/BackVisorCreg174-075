namespace Core.CustomEntities.Oracle
{
    public class SolServicioConexionFactibilidadDetalleCuentasRequest
    {

        public long CodSolServicioConexionFactibilidad { get; set; }

        public int CodTipoCarga { get; set; }

        public int CodTipoClaseCarga { get; set; }

        public decimal ValorCarga { get; set; }
    }
}
