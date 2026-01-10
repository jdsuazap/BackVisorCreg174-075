namespace Application.SQLContext.SolServicioConexionReciboTecnico.DTOs
{
    using Application.SQLContext.SolReciboTecnico.DTOs;

    public class ReciboTecnicoDTO
    {
        public long Id { get; set; }
        public int Etapa { get; set; }
        public ReciboTecnicoBaseDTO ReciboTecnicoInfo { get; set; }       
    }
}
