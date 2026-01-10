namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class CregDepartamentoConfiguration : IEntityTypeConfiguration<CregDepartamento>
    {
        public void Configure(EntityTypeBuilder<CregDepartamento> entity)
        {
            entity.ToTable("CREG_DEPARTAMENTO");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID");

            entity.Property(e => e.Abreviatura)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ABREVIATURA");

            entity.Property(e => e.CodigoDane)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CODIGO_DANE");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1\n   ");

            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_DEPARTAMENTO");
        }
    }
}
