using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class CountryCurrencyConfiguration : IEntityTypeConfiguration<CountryCurrencyEntity>
{
    public void Configure(EntityTypeBuilder<CountryCurrencyEntity> builder)
    {
        builder.ToTable("cat_moneda_pais");
        builder.HasKey(x => x.Id).HasName("pk_cat_moneda_pais");

        builder.Property(x => x.Id).HasColumnName("id_moneda_pais").UseIdentityAlwaysColumn();
        builder.Property(x => x.CountryName).HasColumnName("pais").HasMaxLength(80);
        builder.Property(x => x.CurrencyCode).HasColumnName("clave_moneda").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");

        builder.HasOne(x => x.Currency)
            .WithMany()
            .HasForeignKey(x => x.CurrencyCode)
            .HasConstraintName("fk_cat_moneda_pais_clave_moneda")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
