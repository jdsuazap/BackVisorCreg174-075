namespace Application.Oracle.Ciudad.Queries
{
    using Application.Oracle.Ciudad.DTOs;
    using MediatR;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CiudadSearchByDptoQuery : IRequest<List<CiudadDTO>>
    {
        [Required]
        public string CodDepartamento { get; set; }
    }
}
