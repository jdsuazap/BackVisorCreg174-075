namespace Application.Oracle.SolServicioConexionReciboTecnico.DTOs
{
    using Application.Oracle.SolReciboTecnico.DTOs;

    public class SolServicioConexionReciboTecnicoPorEtapasDTO
    {
        public int Etapa { get; set; }
        public List<SolServicioConexionReciboTecnicoDTO> RecibosTecnicos { get; set; }
    }
}
