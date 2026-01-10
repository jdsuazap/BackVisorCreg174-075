using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using Core.Exceptions;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class StringBaseRepository<T> : IStringRepository<T> where T : StringBaseEntity
    {
        // Colocar como private, cuando sea necesario, pero este proceso arrojaría errores.
        // Se coloca protected para poder utilizar para ejecutar querys que contengan funciones, procedimientos almacenados, etc.
        protected readonly DbSQLContext _context;
        protected readonly DbSet<T> _entities;

        public StringBaseRepository(DbSQLContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool isTracking = false, params Expression<Func<T, object>>[] includeObjectProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeObjectProperties != null)
            {
                foreach (Expression<Func<T, object>> include in includeObjectProperties)
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return (!isTracking) ? await query.AsNoTracking().ToListAsync() : await query.ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            try
            {
                await _entities.AddAsync(entity);
                await Commit();
            }
            catch (System.Exception e)
            {
                throw new BusinessException(string.Concat("Se produjo un error al agregar la entidad en la base de datos.", e.InnerException?.Message ?? e.Message));
            }
        }

        public async Task AddRange(List<T> entities)
        {
            try
            {
                await _context.AddRangeAsync(entities);
                await Commit();
            }
            catch (System.Exception e)
            {
                throw new BusinessException(string.Concat("Se produjo un error al agregar entidades en la base de datos.", e.InnerException?.Message ?? e.Message));
            }           
        }

        public async Task Update(T entity)
        {
            try
            {
                _entities.Update(entity);
                await Commit();
            }
            catch (System.Exception e)
            {
                throw new BusinessException(string.Concat("Se produjo un error al actualizar la entidad en la base de datos.", e.InnerException?.Message ?? e.Message));
            }            
        }

        public async Task Delete(string id)
        {
            try
            {
                T entity = await GetById(id);
                _entities.Remove(entity);
                await Commit();
            }
            catch (System.Exception e)
            {
                throw new BusinessException(string.Concat("Se produjo un error al eliminar la entidad en la base de datos.", e.InnerException?.Message ?? e.Message));
            }
        }

        private async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task ExecuteNonQuery(string sqlCommand)
        {
            try
            {
                string cadenaConexion = _context.Database.GetConnectionString();

                using SqlConnection conexion = new SqlConnection { ConnectionString = cadenaConexion };

                await conexion.OpenAsync();

                SqlCommand command = new SqlCommand(sqlCommand, conexion);

                await command.ExecuteNonQueryAsync();

                await conexion.CloseAsync();
                await conexion.DisposeAsync();
            }
            catch (System.Exception e)
            {
                throw new BusinessException(string.Concat("Se produjo un error al ejecutar query en la base de datos.", e.InnerException?.Message ?? e.Message));
            }            
        }
    }
}
