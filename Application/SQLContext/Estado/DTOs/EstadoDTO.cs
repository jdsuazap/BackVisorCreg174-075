namespace Application.SQLContext.Estado.DTOs
{
    public class EstadoDTO
    {
        public int Id { get; set; }
        public int ParIdEstado { get; set; }
        public int CodTipoEstado { get; set; }
        public int? CodEtapa { get; set; }
        public string ParDescripcion { get; set; }
        public bool? ParvEstado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }

        //public virtual ICollection<SolServicioConexion> SolServicioConexions { get; set; }
        //public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
