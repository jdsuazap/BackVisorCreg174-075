namespace Infrastructure.Factories
{
    using Core.CustomEntities;
    using Core.Enumerations;
    using Core.Exceptions;
    using Infrastructure.Interfaces;
    using Microsoft.Data.SqlClient;
    using Oracle.ManagedDataAccess.Client;
    using System.Data;

    public class DbConnectionFactorySingular : IDbConnectionFactory
    {
        private readonly DbConnectionFactoryModel _internal;

        public DbConnectionFactorySingular(DbConnectionFactoryModel connection)
        {
            _internal = connection;
        }

        public IDbConnection CreateDbConnection(EnumConnectionStrings connectionName)
        {
            // Aquí ignoramos connectionName porque el adaptador es específico para uno
            return _internal.TipoDB switch
            {
                EnumDatabaseType.SqlServer => new SqlConnection(_internal.ConnectionString),
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
