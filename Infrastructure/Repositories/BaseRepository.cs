namespace Infrastructure.Repositories
{
    using Core.Entities;
    using Core.Exceptions;
    using Core.Interfaces;
    using Dapper;
    using Infrastructure.Data;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System.Data;
    using System.Linq.Expressions;

    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbSQLContext _context;
        protected readonly DbSet<T> _entities;
        protected readonly IDbConnection? _dapperContext;

        public BaseRepository(
            DbSQLContext context,
            IDbConnection? dapperContext = null
        )
        {
            _context = context;
            _dapperContext = dapperContext;
            _entities = _context.Set<T>();
        }

        #region Métodos DbSQLContext
        public async Task<List<T>> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderByDescending = null,
            bool isTracking = false,
            params Expression<Func<T, object>>[] includeObjectProperties)
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

            if (orderByDescending != null)
            {
                return await orderByDescending(query).ToListAsync();
            }

            return (!isTracking) ? await query.AsNoTracking().ToListAsync() : await query.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            //return await _entities.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            try
            {
                await _entities.AddAsync(entity);
                await Commit();
            }
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
            {
                throw new BusinessException(string.Concat("Se produjo un error al actualizar la entidad en la base de datos.", e.InnerException?.Message ?? e.Message));
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                T entity = await GetById(id);
                _entities.Remove(entity);
                await Commit();
            }
            catch (Exception e)
            {
                throw new BusinessException(string.Concat("Se produjo un error al eliminar la entidad en la base de datos.", e.InnerException?.Message ?? e.Message));
            }
        }

        public async Task DeleteEntityRange(List<T> entities)
        {
            try
            {
                _context.RemoveRange(entities);
                await Commit();
            }
            catch (Exception e)
            {
                throw new BusinessException(string.Concat("Se produjo un error al eliminar entidades en la base de datos.", e.InnerException?.Message ?? e.Message));
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
            catch (Exception e)
            {
                throw new BusinessException(string.Concat("Se produjo un error al ejecutar query en la base de datos.", e.InnerException?.Message ?? e.Message));
            }
        }
        #endregion

        #region Métodos Dapper
        public async Task<IEnumerable<T>> Dapper_GetEntities(string query, Type[] relatedEntities, Func<object[], T> mapFunc, Func<IEnumerable<T>, IEnumerable<T>> groupAndProjectFunc, object param)
        {
            //string splitOn = DapperSplitOn.ConstruirSplitOn(relatedEntities);
            string splitOn = "Id";
            var result = await _dapperContext.QueryAsync(query, relatedEntities, (objects) => { return mapFunc(objects); }, param, splitOn: splitOn);

            // Aplicar la función de agrupar y proyectar
            var groupedAndProjectedResult = groupAndProjectFunc(result);

            return groupedAndProjectedResult;
        }

        public async Task<IEnumerable<T>> Dapper_GetEntities(string query, Type[] relatedEntities, Func<object[], T> mapFunc, object param)
        {
            //string splitOn = DapperSplitOn.ConstruirSplitOn(relatedEntities);
            string splitOn = "Id";
            var result = await _dapperContext.QueryAsync(query, relatedEntities, (objects) => { return mapFunc(objects); }, param, splitOn: splitOn);

            return result;
        }

        #endregion
    }
}
