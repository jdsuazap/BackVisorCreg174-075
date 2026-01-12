namespace Application.Oracle.DocumentosXformulario.DTOs
{
    public class DocumentosXformularioDTO
    {
        public int Id { get; set; }
        public int CodFormularioPrincipal { get; set; }
        public string NombreDocumento { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public bool Requiered { get; set; }
        public long LimitLoad { get; set; }
        public bool Vigencia { get; set; }
        public int VigenciaMaxima { get; set; }
        public bool? IsCampo { get; set; }

        //public virtual FormularioDocumento CodFormularioPrincipalNavigation { get; set; }
        //public virtual ICollection<SolConexionAutogenAnexo> SolConexionAutogenAnexos { get; set; }
        //public virtual ICollection<SolConexionAutogenXprorrogaAnexo> SolConexionAutogenXprorrogaAnexos { get; set; }
        //public virtual ICollection<SolConexionAutogenXvisitaAnexo> SolConexionAutogenXvisitaAnexos { get; set; }
        //public virtual ICollection<SolReciboTecnicoAnexo> SolReciboTecnicoAnexos { get; set; }
        //public virtual ICollection<SolRevisionEstudioAnexo> SolRevisionEstudioAnexos { get; set; }
        //public virtual ICollection<SolServicioConexionAnexo> SolServicioConexionAnexos { get; set; }
    }
}
