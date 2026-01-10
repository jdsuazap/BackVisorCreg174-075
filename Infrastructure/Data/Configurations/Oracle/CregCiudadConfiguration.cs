namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class CregCiudadConfiguration : IEntityTypeConfiguration<CregCiudad>
    {
        public void Configure(EntityTypeBuilder<CregCiudad> entity)
        {
            entity.ToTable("CREG_CIUDAD");

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ID");

            entity.Property(e => e.CodDepartamento)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COD_DEPARTAMENTO");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1\n   ");

            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CIUDAD");
        }
    }
}
