namespace Application.Oracle.SolConexionAutogen.DTOs
{
    public class InfoFormularioDTO
    { 
        //Datos de infraestructura
        public string Transformador { get; set; }
        public string PorcentajeTransformador { get; set; }
        public decimal? Cap_Max_Disponible { get; set; }
        public decimal? Tot_Cap_Ocupada { get; set; }

    }
}
