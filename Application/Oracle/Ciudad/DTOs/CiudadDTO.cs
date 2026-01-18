namespace Application.Oracle.Ciudad.DTOs
{
    using System;

    public class CiudadDTO
    {
        public string Id { get; set; }
        public string CodDepartamento { get; set; }
        public string NombreCiudad { get; set; }
        public bool? Estado { get; set; }

        //public virtual Departamento CodDepartamentoNavigation { get; set; }
        //public virtual ICollection<UsuarioCliente> UsuarioClientes { get; set; }
    }
}
