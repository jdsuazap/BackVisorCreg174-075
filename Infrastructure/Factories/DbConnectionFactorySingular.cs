namespace Infrastructure.Factories
{
    using Core.CustomEntities;
    using Core.Enumerations;
    using Core.Exceptions;
    using Dapper;
    using Infrastructure.Interfaces;
    using Oracle.ManagedDataAccess.Client;
    using System.Data;

    public class DbConnectionFactorySingular : IDbConnectionFactory
    {
        private readonly DbConnectionFactoryModel _internal;

        public DbConnectionFactorySingular(DbConnectionFactoryModel connection)
        {
            _internal = connection;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(
            string sql,
            object param = null,
            EnumConnectionStrings connectionName = EnumConnectionStrings.BaseDeDatoOracleEEP
        )
        {
            using var conn = CreateDbConnection(connectionName);
            return await conn.QueryAsync<T>(sql, param);
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<T1, T2, TReturn>(
            string sql,
            Func<T1, T2, TReturn> map,
            object param = null,
            string splitOn = "Id",
            EnumConnectionStrings connectionName = EnumConnectionStrings.BaseDeDatoOracleEEP
        )
        {
            using var conn = CreateDbConnection(connectionName);
            return await conn.QueryAsync(sql, map, param, splitOn: splitOn);
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<T1, T2, T3, TReturn>(
            string sql,
            Func<T1, T2, T3, TReturn> map,
            object param = null,
            string splitOn = "Id",
            EnumConnectionStrings connectionName = EnumConnectionStrings.BaseDeDatoOracleEEP
        )
        {
            using var conn = CreateDbConnection(connectionName);
            return await conn.QueryAsync(sql, map, param, splitOn: splitOn);
        }

        public IDbConnection CreateDbConnection(EnumConnectionStrings connectionName)
        {
            // Aquí ignoramos connectionName porque el adaptador es específico para uno
            return _internal.TipoDB switch
            {
                EnumDatabaseType.Oracle => new OracleConnection(_internal.ConnectionString),
                _ => throw new BusinessException($"Tipo de base de datos '{_internal.TipoDB}' no soportado.")
            };
        }

        public string GetProvider(EnumConnectionStrings connectionName)
        {
            return connectionName switch
            {
                EnumConnectionStrings.BaseDeDatosSqlServer => nameof(EnumDatabaseType.SqlServer),
                EnumConnectionStrings.BaseDeDatoOracleEEP => nameof(EnumDatabaseType.Oracle),
                _ => throw new NotSupportedException("Base de datos no soportada")
            };
        }
    }
}
