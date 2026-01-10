namespace Application.Oracle.Ciudad.DTOs
{
    using System;

    public class CiudadDTO
    {
        public string Id { get; set; }
        public string CodDepartamento { get; set; }
        public string NombreCiudad { get; set; }
        public bool? Estado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }

        //public virtual Departamento CodDepartamentoNavigation { get; set; }
        //public virtual ICollection<UsuarioCliente> UsuarioClientes { get; set; }
    }
}
