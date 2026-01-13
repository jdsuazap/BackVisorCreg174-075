namespace Core.CustomEntities
{
    public class TransformadorCircuitoDto
    {
        // Transformador
        public string Direccion { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public string Codigo { get; set; }
        public string Uia { get; set; }
        public string Propietario { get; set; }
        public decimal? Volt_Nominal { get; set; }
        public decimal? Cap_Kva { get; set; }
        public decimal? Gen_Instalada { get; set; }
        public decimal? Cap_Max_Disponible { get; set; }
        public decimal? Tot_Cap_Ocupada { get; set; }
        public decimal? Energia_Trafo { get; set; }
        public decimal? Ener_Gen_No_Fv { get; set; }
        public decimal? Tot_Ener_Hor_Ocupada { get; set; }
        public decimal? Cap_Max_Ener_Hor_Disponible { get; set; }
        public decimal? Energia_Fv { get; set; }
        public decimal? Ener_Hor_Ocup_Fv { get; set; }
        public decimal? Ener_Hor_Dispo_Fv { get; set; }

        // Circuito
        public string Circuito { get; set; }
        public decimal? Volt_Nominal_Circ { get; set; }
        public decimal? Cap_Kva_Circ { get; set; }
        public decimal? Generacion_Inst { get; set; }
        public decimal? Cap_Max_Disponible_Circ { get; set; }
        public decimal? Tot_Cap_Ocupada_Circ { get; set; }
        public decimal? Energia_Circ { get; set; }
        public decimal? Ener_Gener_No_Fv_Circ { get; set; }
        public decimal? Tot_Ener_Hor_Ocup_Circ { get; set; }
        public decimal? Cap_Max_Ene_Circ { get; set; }
        public decimal? Energia_Fv_Circ { get; set; }
        public decimal? Ener_Gener_Fv_Circ { get; set; }
        public decimal? Ener_Hor_Ocup_Fv_Circ { get; set; }
        public decimal? Ener_Hor_Dispo_Fv_Circ { get; set; }
    }
}
