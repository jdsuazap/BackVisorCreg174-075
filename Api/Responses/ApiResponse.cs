using Core.CustomEntities;
using Core.Entities;
using System.Collections.Generic;

namespace Api.Responses
{
    public class ApiResponse<T>
    {
        //private (List<FormasPago>, List<TipoUsuario>) list;
        private int v;

        public int Status { get; set; }
        public T Data { get; set; }
        public Metadata Metadata { get; set; }
        
        public ApiResponse(T data, int status)
        {
            Data = data;
            Status = status;
        }

        public ApiResponse(T data, int status, int totalRecords)
        {
            Data = data;
            Status = status;
        }

        public ApiResponse(T data, int status, Metadata meta)
        {
            Data = data;
            Status = status;
            Metadata = meta;
        }
    }
}
