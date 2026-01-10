using Core.Exceptions;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data.Common;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Core.Enumerations;

namespace Infrastructure.Repositories
{
    public class BaseRepositoryDapperOracle<T> : IRepositoryDapper<T> where T : class
    {
        protected readonly DbOracleContext _context;
        protected readonly IDbConnectionFactory _dapperContext;
        protected readonly DbSet<T> _entities;
        protected string _NombreVariableEntrada;
        protected string _NombreVariableSalida;

        public BaseRepositoryDapperOracle(
            DbOracleContext context,
            string nombreVariableEntrada,
            string nombreVariableSalida,
            IDbConnectionFactory dapperContext = null
            )
        {
            _context = context;
            _dapperContext = dapperContext;
            _entities = context.Set<T>();
            _NombreVariableEntrada = nombreVariableEntrada;
            _NombreVariableSalida = nombreVariableSalida;
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

        public Task AddRange(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Dapper_GetEntities(string query, Type[] relatedEntities, Func<object[], T> mapFunc, Func<IEnumerable<T>, IEnumerable<T>> groupAndProjectFunc, object param)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ExecuteNonQuery(string sqlCommand, List<OracleParameter> parameters, string outParameterName)
        {
            string result = null;
            try
            {
                // Crear una nueva conexión por cada solicitud
                using var connection = _dapperContext.CreateDbConnection(EnumConnectionStrings.BaseDeDatoOracleEEP);

                // Abrir la conexión si está cerrada
                await OpenConnectionAsync(connection);

                // Crear el comando y agregar los parámetros
                using (OracleCommand command = new OracleCommand(sqlCommand, (OracleConnection)connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    command.CommandType = CommandType.StoredProcedure;

                    // Ejecutar el comando asincrónicamente
                    await command.ExecuteNonQueryAsync();

                    // Obtener el valor del parámetro de salida
                    var outputClob = (OracleClob)command.Parameters[outParameterName].Value;
                    result = outputClob.Value;
                }

                await CloseConnectionAsync((OracleConnection)connection);
            }
            catch (Exception e)
            {
                throw new BusinessException(string.Concat("Se produjo un error al ejecutar query en la base de datos.", e.InnerException?.Message ?? e.Message));
            }
            return result;
        }

        public Task ExecuteNonQuery(string sqlCommand)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderByDescending = null,
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

            return !isTracking ? await query.AsNoTracking().ToListAsync() : await query.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
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

        #region IMPLEMENTACION DE ORACLE

        public async Task<T?> EjecutarConsultaAsync<T>(string query) where T : class
        {
            try
            {
                using var connection = _dapperContext.CreateDbConnection(EnumConnectionStrings.BaseDeDatoOracleEEP);
                await ((OracleConnection)connection).OpenAsync();

                var result = await connection.QueryFirstOrDefaultAsync<T>(query);

                await ((OracleConnection)connection).CloseAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al ejecutar la consulta. {ex.Message}");
            }
        }

        public async Task<IEnumerable<T>> EjecutarConsultaListAsync<T>(string query) where T : class
        {
            try
            {
                using var connection = _dapperContext.CreateDbConnection(EnumConnectionStrings.BaseDeDatoOracleEEP);
                await ((OracleConnection)connection).OpenAsync();

                var result = await connection.QueryAsync<T>(query);

                await ((OracleConnection)connection).CloseAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al ejecutar la consulta. {ex.Message}");
            }
        }

        public static async Task OpenConnectionAsync(IDbConnection connection)
        {
            // Abrir la conexión si está cerrada
            if (connection.State == ConnectionState.Closed)
            {
                if (connection is OracleConnection oracleConnection)
                {
                    if (!oracleConnection.KeepAlive)
                    {
                        oracleConnection.KeepAlive = true;
                    }

                    await oracleConnection.OpenAsync();  // Conexión Oracle Asíncrona
                }
                else
                {
                    connection.Open(); // Para otras conexiones
                }
            }
        }

        public static async Task CloseConnectionAsync(DbConnection connection)
        {
            if (connection is OracleConnection)
            {
                // Cerrar la conexión (Asincrónico)
                await connection.CloseAsync();
                await connection.DisposeAsync(); // También podemos disponer la conexión para liberar recursos
            }
            else
            {
                // Cerrar la conexión (sincrónico)
                connection.Close();
                connection.Dispose(); // También podemos disponer la conexión para liberar recursos
            }
        }

        protected async Task<T> DapperExecuteStoreProcedureAsync<T>(string storeProcedure, List<OracleParameter> parameters = null, bool unescaped = true)
        {
            try
            {
                // Crear una nueva conexión por cada solicitud
                using var connection = _dapperContext.CreateDbConnection(EnumConnectionStrings.BaseDeDatoOracleEEP);

                // Abrir la conexión si está cerrada
                await OpenConnectionAsync(connection);

                // Crear y ejecutar el comando
                using var command = CreateCommand(storeProcedure, parameters, (OracleConnection)connection);
                await command.ExecuteScalarAsync(); // Ejecución asincrónica
                var resp = await ReadOutputParameterAsync<T>(command, unescaped);

                await CloseConnectionAsync((OracleConnection)connection);

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing stored procedure. {ex.Message}", ex.InnerException);
            }
        }

        private OracleCommand CreateCommand(string commandText, List<OracleParameter> parameters, OracleConnection connection, CommandType commandType = CommandType.StoredProcedure)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandType = commandType;
                command.CommandText = commandText;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                return command;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating command. {ex.Message}", ex.InnerException);
            }
        }

        private DynamicParameters MapEntityToParameters<T>(T entity)
        {
            var parameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                parameters.Add(propertyName, propertyValue);
            }
            return parameters;
        }

        private string Unescape(string input)
        {
            string textoConSecuenciaDeEscape = input;
            string textoDecodificado = Regex.Unescape(textoConSecuenciaDeEscape);
            byte[] bytesUtf8 = Encoding.UTF8.GetBytes(textoDecodificado);
            string textoOriginal = Encoding.UTF8.GetString(bytesUtf8);
            return textoOriginal;
        }

        private async Task<T> ReadOutputParameterAsync<T>(OracleCommand command, bool unescaped = true)
        {
            var outputClob = (OracleClob)command.Parameters[_NombreVariableSalida].Value;
            var outputValue = outputClob.Value;

            if (!unescaped)
            {
                return await DeserializarAsync<T>(outputValue);
            }

            var outputUnescape = Unescape(outputValue);
            return await DeserializarAsync<T>(outputUnescape);
        }

        private static async Task<T> DeserializarAsync<T>(string jsonString)
        {
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(jsonString));
        }

        private void AddOutputParameter(OracleCommand command)
        {
            var outputParameter = new OracleParameter(_NombreVariableSalida, OracleDbType.Clob)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(outputParameter);
        }


        private async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
