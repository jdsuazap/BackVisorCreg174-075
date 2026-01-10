using Application.SQLContext.SolServicioConexionDetalleCuentas.DTOs;
using AutoMapper;

namespace Application.SQLContext.SolServicioConexionDetalleCuentas.Mapping
{
    internal class SolServicioConexionDetalleCuentasMapper : Profile
    {
        public SolServicioConexionDetalleCuentasMapper()
        {
            CreateMap<Core.Entities.SQLContext.SolServicioConexionDetalleCuenta, SolServicioConexionDetalleCuentasDTO>().ReverseMap();
        }
    }
}
