namespace Infrastructure.Interfaces
{
    using Core.Enumerations;
    using System.Data;

    public interface IDbConnectionFactory
    {
        Task<IEnumerable<T>> QueryAsync<T>(
        string sql,
        object param = null,
        EnumConnectionStrings connectionName = EnumConnectionStrings.BaseDeDatoOracleEEP
        );

        Task<IEnumerable<TReturn>> QueryAsync<T1, T2, TReturn>(
            string sql,
            Func<T1, T2, TReturn> map,
            object param = null,
            string splitOn = "Id",
            EnumConnectionStrings connectionName = EnumConnectionStrings.BaseDeDatoOracleEEP
        );

        IDbConnection CreateDbConnection(EnumConnectionStrings connectionName);
        string GetProvider(EnumConnectionStrings connectionName);
    }
}

