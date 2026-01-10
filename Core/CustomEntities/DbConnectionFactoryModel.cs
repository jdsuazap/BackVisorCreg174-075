namespace Core.CustomEntities
{
    using Core.Enumerations;

    public class DbConnectionFactoryModel
    {
        public EnumDatabaseType TipoDB { get; set; }
        public string ConnectionString { get; set; }
    }
}
