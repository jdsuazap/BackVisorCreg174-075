namespace Infrastructure.Data
{
    using Core.Entities.Oracle;
    using Infrastructure.Extensions;
    using Microsoft.EntityFrameworkCore;

    public class DbSpardContext : DbContext
    {
        public DbSpardContext()
        {
        }

        public DbSpardContext(DbContextOptions<DbSpardContext> options)
            : base(options)
        {
        }
        //public virtual DbSet<Feeder> Feeder { get; set; }
        //public virtual DbSet<Lvelnode> Lvelnode { get; set; }
        //public virtual DbSet<Mvlinsec> Mvlinsec { get; set; }
        //public virtual DbSet<Lvlinsec> Lvlinsec { get; set; }
        //public virtual DbSet<Mvelnode> Mvelnode { get; set; }
        public virtual DbSet<Transfor> Transfor { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("CONS_INFO_CREG");
            modelBuilder.ApplyAllConfigurations();
        }
    }
}

