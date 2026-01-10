using Application.SQLContext.SolServicioConexionComentario.DTOs;
using AutoMapper;

namespace Application.SQLContext.SolServicioConexionComentario.Mapping
{
    internal class SolConexionAutogenComentarioMapper : Profile
    {
        public SolConexionAutogenComentarioMapper()
        {
            CreateMap<Core.Entities.SQLContext.SolServicioConexionComentario, SolServicioConexionComentarioDTO>().ReverseMap();
        }
    }
}
