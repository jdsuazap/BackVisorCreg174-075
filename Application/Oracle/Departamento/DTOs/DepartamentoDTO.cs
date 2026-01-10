namespace Application.Oracle.Departamento.DTOs
{
    public class DepartamentoDTO
    {
        public string Id { get; set; }
        public string CodigoDane { get; set; }
        public string NombreDepartamento { get; set; }
        public bool? Estado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }

        //public virtual ICollection<Departamento> Departamentos { get; set; }
        //public virtual ICollection<UsuarioCliente> UsuarioClientes { get; set; }
    }
}
