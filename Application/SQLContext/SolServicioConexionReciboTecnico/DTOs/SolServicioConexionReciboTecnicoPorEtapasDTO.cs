namespace Application.SQLContext.SolServicioConexionReciboTecnico.DTOs
{
    using Application.SQLContext.SolReciboTecnico.DTOs;
    public class SolServicioConexionReciboTecnicoPorEtapasDTO
    {
        public int Etapa { get; set; }
        public List<SolServicioConexionReciboTecnicoDTO> RecibosTecnicos { get; set; }
    }
}
