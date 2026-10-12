using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.Core.Operative;

public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
{
    public void Configure(EntityTypeBuilder<ClientEntity> builder)
    {
        builder.ToTable("ope_cliente");
        builder.HasKey(x => x.Id).HasName("pk_ope_cliente");

        builder.Property(x => x.Id).HasColumnName("id_cliente").UseIdentityAlwaysColumn();
        builder.Property(x => x.Rfc).HasColumnName("rfc").HasMaxLength(13);
        builder.Property(x => x.Curp).HasColumnName("curp").HasMaxLength(18);
        builder.Property(x => x.BusinessName).HasColumnName("razon_social").HasMaxLength(150);
        builder.Property(x => x.Address).HasColumnName("domicilio").HasMaxLength(250);
        builder.Property(x => x.NotificationEmail).HasColumnName("correo_avisos").HasMaxLength(120);

        builder.HasIndex(x => x.Rfc).IsUnique().HasDatabaseName("uq_ope_cliente_1");
    }
}
