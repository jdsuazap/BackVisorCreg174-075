namespace Core.Entities.SQLContext
{
    public class SolServicioConexionReview : GenericBaseEntity<long>
    {
        public SolServicioConexionReview()
        {
        }

        /// <summary>
        /// Id de la solicitud
        /// </summary>
        public int CodSolServicioConexion { get; set; }
        /// <summary>
        /// Descripción del rechazo
        /// </summary>
        public long? CodDisenio { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int CodEstado { get; set; }
        public bool Aprobado { get; set; }
        public string ProcedimientoOrigen { get; set; }
        public int Etapa { get; set; }
        public virtual SolServicioConexion CodSolServicioConexionNavigation { get; set; } = null!;
    }

}
