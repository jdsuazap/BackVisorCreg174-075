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
        public int TotalRecords { get; set; }
        
        public ApiResponse(T data, int status)
        {
            Data = data;
            Status = status;
            TotalRecords = 0;
        }

        public ApiResponse(T data, int status, int totalRecords)
        {
            Data = data;
            Status = status;
            TotalRecords = totalRecords;
        }

        public ApiResponse(T data, int status, Metadata meta)
        {
            Data = data;
            Status = status;
            Metadata = meta;
        }

        /*public ApiResponse((List<FormasPago>, List<TipoUsuario>) list, int v)
        {
            this.list = list;
            this.v = v;
        }*/
    }
}
