namespace Infrastructure.Interfaces
{
    using Core.Enumerations;
    using System.Data;

    public interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection(EnumConnectionStrings connectionName);
        string GetProvider(EnumConnectionStrings connectionName);
    }
}

