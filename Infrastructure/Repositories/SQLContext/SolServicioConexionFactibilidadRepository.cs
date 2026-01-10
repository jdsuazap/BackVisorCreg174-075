using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.SQLContext
{
    public class SolServicioConexionFactibilidadRepository : GenericBaseRepository<SolServicioConexionFactibilidad>, ISolServicioConexionFactibilidadRepository
    {
        public SolServicioConexionFactibilidadRepository(DbSQLContext context) : base(context) { }

        public async Task<SolServicioConexionFactibilidad> CreateEntity(SolServicioConexionFactibilidad entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(SolServicioConexionFactibilidad entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<SolServicioConexionFactibilidad>> GetEntities()
        {
            return await GetAllAsync();
        }

        public async Task<SolServicioConexionFactibilidad> GetEntity(long idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<SolServicioConexionFactibilidad> UpdateEntity(SolServicioConexionFactibilidad entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.NumeroFactibilidad = entity.NumeroFactibilidad;
            entidad.Info = entity.Info;
            entidad.Estado = entity.Estado;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return entidad;
        }
    }
}
