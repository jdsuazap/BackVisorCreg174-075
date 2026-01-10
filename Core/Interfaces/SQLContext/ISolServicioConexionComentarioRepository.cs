using Core.Entities.SQLContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.SQLContext
{
    public interface ISolServicioConexionComentarioRepository
    {
        Task<SolServicioConexionComentario> CreateEntity(SolServicioConexionComentario entity);
        Task<SolServicioConexionComentario> DeleteEntity(SolServicioConexionComentario entity);
        Task<List<SolServicioConexionComentario>> GetEntities();
        Task<SolServicioConexionComentario> GetEntity(int idEntity);
        Task<List<SolServicioConexionComentario>> GetEntitiesByRequest( int idRequest);
        Task<List<SolServicioConexionComentario>> GetEntitiesRequestDetailsById(int idRequest);
        Task<SolServicioConexionComentario> UpdateEntity(SolServicioConexionComentario entity);
    }
}
