using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Operative;

public class PedimentoTransportConfiguration : IEntityTypeConfiguration<PedimentoTransportEntity>
{
    public void Configure(EntityTypeBuilder<PedimentoTransportEntity> builder)
    {
        builder.ToTable("ope_transporte_pedimento");
        builder.HasKey(x => x.Id).HasName("pk_ope_transporte_pedimento");

        builder.Property(x => x.Id).HasColumnName("id_transporte").UseIdentityAlwaysColumn();
        builder.Property(x => x.PedimentoId).HasColumnName("id_pedimento");
        builder.Property(x => x.Identification).HasColumnName("identificacion").HasMaxLength(50);
        builder.Property(x => x.CountryCode).HasColumnName("clave_pais").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.Carrier).HasColumnName("transportista").HasMaxLength(150);

        builder.HasOne(x => x.Pedimento)
            .WithMany(x => x.Transports)
            .HasForeignKey(x => x.PedimentoId)
            .HasConstraintName("fk_ope_transporte_pedimento_id_pedimento")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Country)
            .WithMany()
            .HasForeignKey(x => x.CountryCode)
            .HasConstraintName("fk_ope_transporte_pedimento_clave_pais")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
