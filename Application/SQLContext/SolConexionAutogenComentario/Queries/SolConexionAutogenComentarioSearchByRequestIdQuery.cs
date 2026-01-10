using Application.SQLContext.SolConexionAutogenComentario.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SQLContext.SolConexionAutogenComentario.Queries
{
    public class SolConexionAutogenComentarioSearchByRequestIdQuery : IRequest<List<SolConexionAutogenComentarioDTO>>
    {
        [Required]
        public int Id { get; set; }
    }
}
