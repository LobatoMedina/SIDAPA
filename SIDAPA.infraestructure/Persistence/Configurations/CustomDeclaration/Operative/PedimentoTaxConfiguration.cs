using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Operative;

public class PedimentoTaxConfiguration : IEntityTypeConfiguration<PedimentoTaxEntity>
{
    public void Configure(EntityTypeBuilder<PedimentoTaxEntity> builder)
    {
        builder.ToTable("ope_contribucion_pedimento");
        builder.HasKey(x => x.Id).HasName("pk_ope_contribucion_pedimento");

        builder.Property(x => x.Id).HasColumnName("id_contribucion_ped").UseIdentityAlwaysColumn();
        builder.Property(x => x.PedimentoId).HasColumnName("id_pedimento");
        builder.Property(x => x.TaxCode).HasColumnName("clave_contribucion");
        builder.Property(x => x.RateTypeCode).HasColumnName("clave_tipo_tasa").HasMaxLength(2);
        builder.Property(x => x.Rate).HasColumnName("tasa").HasPrecision(10, 4);
        builder.Property(x => x.PaymentMethodCode).HasColumnName("clave_forma_pago").HasMaxLength(2);
        builder.Property(x => x.Amount).HasColumnName("importe").HasPrecision(16, 2);

        builder.HasOne(x => x.Pedimento)
            .WithMany(x => x.Taxes)
            .HasForeignKey(x => x.PedimentoId)
            .HasConstraintName("fk_ope_contribucion_pedimento_id_pedimento")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Tax)
            .WithMany()
            .HasForeignKey(x => x.TaxCode)
            .HasConstraintName("fk_ope_contribucion_pedimento_clave_contribucion")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.RateType)
            .WithMany()
            .HasForeignKey(x => x.RateTypeCode)
            .HasConstraintName("fk_ope_contribucion_pedimento_clave_tipo_tasa")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PaymentMethod)
            .WithMany()
            .HasForeignKey(x => x.PaymentMethodCode)
            .HasConstraintName("fk_ope_contribucion_pedimento_clave_forma_pago")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
