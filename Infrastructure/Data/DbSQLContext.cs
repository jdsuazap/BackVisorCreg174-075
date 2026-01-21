namespace Infrastructure.Data
{
    using Core.ModelResponse;
    using Infrastructure.Extensions;
    using Microsoft.EntityFrameworkCore;

    public partial class DbSQLContext : DbContext
    {
        public DbSQLContext()
        {
        }

        public DbSQLContext(DbContextOptions<DbSQLContext> options)
            : base(options)
        {
        }

        #region Propiedades Contexto
        public DbSet<ResponseInt> ResponseInts { get; set; }
        public virtual DbSet<ResponseAction> ResponseActions { get; set; }
        public virtual DbSet<ResponseActionUrl> ResponseActionUrls { get; set; }
        public virtual DbSet<ResponseJsonString> ResponseJsonStrings { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyAllConfigurations();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
