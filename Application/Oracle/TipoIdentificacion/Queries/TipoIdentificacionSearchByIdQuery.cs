namespace Application.Oracle.TipoIdentificacion.Queries
{
    using Application.Oracle.TipoIdentificacion.DTOs;
    using MediatR;
    using System.ComponentModel.DataAnnotations;
    public class TipoIdentificacionSearchByIdQuery : IRequest<TipoIdentificacionDTO>
    {
        [Required]
        public int Id { get; set; }

        //public SearchByIdQuery(int id)
        //{
        //    Id = id;
        //}
    }
}
