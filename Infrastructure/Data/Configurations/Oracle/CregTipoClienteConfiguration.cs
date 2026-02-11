namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class CregTipoClienteConfiguration : IEntityTypeConfiguration<CregTipoCliente>
    {
        public void Configure(EntityTypeBuilder<CregTipoCliente> entity)
        {
            entity.ToTable("CREG_TIPO_CLIENTE");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1\n   ");
        }
    }

}
