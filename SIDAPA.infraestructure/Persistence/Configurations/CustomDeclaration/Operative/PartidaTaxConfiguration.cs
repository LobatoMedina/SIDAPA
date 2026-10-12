using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Operative;

public class PartidaTaxConfiguration : IEntityTypeConfiguration<PartidaTaxEntity>
{
    public void Configure(EntityTypeBuilder<PartidaTaxEntity> builder)
    {
        builder.ToTable("ope_contribucion_partida");
        builder.HasKey(x => x.Id).HasName("pk_ope_contribucion_partida");

        builder.Property(x => x.Id).HasColumnName("id_contribucion").UseIdentityAlwaysColumn();
        builder.Property(x => x.PartidaId).HasColumnName("id_partida");
        builder.Property(x => x.TaxCode).HasColumnName("clave_contribucion");
        builder.Property(x => x.RateTypeCode).HasColumnName("clave_tipo_tasa").HasMaxLength(2);
        builder.Property(x => x.Rate).HasColumnName("tasa").HasPrecision(10, 4);
        builder.Property(x => x.PaymentMethodCode).HasColumnName("clave_forma_pago").HasMaxLength(2);
        builder.Property(x => x.Amount).HasColumnName("importe").HasPrecision(16, 2);

        builder.HasOne(x => x.Partida)
            .WithMany(x => x.Taxes)
            .HasForeignKey(x => x.PartidaId)
            .HasConstraintName("fk_ope_contribucion_partida_id_partida")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Tax)
            .WithMany()
            .HasForeignKey(x => x.TaxCode)
            .HasConstraintName("fk_ope_contribucion_partida_clave_contribucion")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.RateType)
            .WithMany()
            .HasForeignKey(x => x.RateTypeCode)
            .HasConstraintName("fk_ope_contribucion_partida_clave_tipo_tasa")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PaymentMethod)
            .WithMany()
            .HasForeignKey(x => x.PaymentMethodCode)
            .HasConstraintName("fk_ope_contribucion_partida_clave_forma_pago")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
