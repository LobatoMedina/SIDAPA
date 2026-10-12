using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRateEntity>
{
    public void Configure(EntityTypeBuilder<ExchangeRateEntity> builder)
    {
        builder.ToTable("cat_tipo_cambio");
        builder.HasKey(x => x.Id).HasName("pk_cat_tipo_cambio");

        builder.Property(x => x.Id).HasColumnName("id_tipo_cambio").UseIdentityAlwaysColumn();
        builder.Property(x => x.Date).HasColumnName("fecha");
        builder.Property(x => x.CurrencyCode).HasColumnName("clave_moneda").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.Rate).HasColumnName("tipo_cambio").HasPrecision(10, 5);
        builder.Property(x => x.EquivalenceFactor).HasColumnName("factor_equivalencia").HasPrecision(14, 8);
        builder.Property(x => x.Source).HasColumnName("fuente").HasMaxLength(20);

        builder.HasIndex(x => new { x.Date, x.CurrencyCode }).IsUnique().HasDatabaseName("uq_cat_tipo_cambio_1");

        builder.HasOne(x => x.Currency)
            .WithMany()
            .HasForeignKey(x => x.CurrencyCode)
            .HasConstraintName("fk_cat_tipo_cambio_clave_moneda")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
