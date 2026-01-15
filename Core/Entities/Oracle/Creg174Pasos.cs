using Core.Entities.SQLContext;

namespace Core.Entities.Oracle
{
    public partial class Creg174Pasos
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int Cod174Autogen { get; set; }
        public int CodEstado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }

        public virtual CregEstado CregEstado { get; set; }
        public virtual Creg174Autogen Creg174Autogen { get; set; }
    }
}
