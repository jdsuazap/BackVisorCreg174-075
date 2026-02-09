using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075Pasos
    {
        public Creg075Pasos()
        {
            Etapa = 1;
        }
        public int Id { get; set; }
        public int Cod075Conexion { get; set; }
        public int CodEstado { get; set; }
        public int Etapa { get; set; }
        public bool? Estado { get; set; }

        public virtual CregEstado CregEstado { get; set; }
        public virtual Creg075ServicioConexion Creg075ServicioConexion { get; set; }
    }
}
