using Application.SQLContext.SolConexionAutogenComentario.DTOs;
using AutoMapper;

namespace Application.SQLContext.SolConexionAutogenComentario.Mapping
{
    internal class SolConexionAutogenComentarioMapper : Profile
    {
        public SolConexionAutogenComentarioMapper()
        {
            CreateMap<Core.Entities.SQLContext.SolConexionAutogenComentario, SolConexionAutogenComentarioDTO>().ReverseMap();
        }
    }
}
