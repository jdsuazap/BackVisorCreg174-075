namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class Creg075SolicitanteConfiguration : IEntityTypeConfiguration<Creg075Solicitante>
    {
        public void Configure(EntityTypeBuilder<Creg075Solicitante> entity)
        {
            
            entity.ToTable("CREG_075_SOLICITANTE");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.AutorizacionNotifEmail)
                .HasPrecision(1)
                .HasColumnName("AUTORIZACION_NOTIF_EMAIL");

            entity.Property(e => e.Celular)
                .HasPrecision(10)
                .HasColumnName("CELULAR");

            entity.Property(e => e.Cod075Conexion)
                .HasPrecision(10)
                .HasColumnName("COD_075_CONEXION");

            entity.Property(e => e.CodDepartamento)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COD_DEPARTAMENTO");

            entity.Property(e => e.CodMunicipio)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("COD_MUNICIPIO");

            entity.Property(e => e.CodTipoDocumento)
                .HasPrecision(10)
                .HasColumnName("COD_TIPO_DOCUMENTO");

            entity.Property(e => e.CodTipoPersona)
                .HasPrecision(10)
                .HasColumnName("COD_TIPO_PERSONA");

            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");

            entity.Property(e => e.EsSolicitantePropietario)
                .HasPrecision(1)
                .HasColumnName("ES_SOLICITANTE_PROPIETARIO");

            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("NUMERO_DOCUMENTO");

            entity.Property(e => e.Telefono)
                .HasPrecision(10)
                .HasColumnName("TELEFONO");

            entity.HasOne(d => d.Cod075ConexionNavigation)
                .WithMany(p => p.Creg075Solicitantes)
                .HasForeignKey(d => d.Cod075Conexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_SOLICITANTE_SERVICIO");

            entity.HasOne(d => d.CodDepartamentoNavigation)
                .WithMany(p => p.Creg075Solicitantes)
                .HasForeignKey(d => d.CodDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_SOLICITANTE_DEPTO");

            entity.HasOne(d => d.CodMunicipioNavigation)
                .WithMany(p => p.Creg075Solicitantes)
                .HasForeignKey(d => d.CodMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_SOLICITANTE_CIUDAD");

            entity.HasOne(d => d.CodTipoDocumentoNavigation)
                .WithMany(p => p.Creg075Solicitantes)
                .HasForeignKey(d => d.CodTipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_SOLICITANTE_T_DOC");

            entity.HasOne(d => d.CodTipoPersonaNavigation)
                .WithMany(p => p.Creg075Solicitantes)
                .HasForeignKey(d => d.CodTipoPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_SOLICITANTE_T_PERS");
            
        }
    }
}
