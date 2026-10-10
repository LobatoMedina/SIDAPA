using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class CountryConfiguration : IEntityTypeConfiguration<CountryEntity>
{
    public void Configure(EntityTypeBuilder<CountryEntity> builder)
    {
        builder.ToTable("cat_pais");
        builder.HasKey(x => x.Code).HasName("pk_cat_pais");

        builder.Property(x => x.Code).HasColumnName("clave_m3").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.FiiiCode).HasColumnName("clave_fiii").HasMaxLength(2).IsFixedLength();
        builder.Property(x => x.Name).HasColumnName("nombre").HasMaxLength(120);
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");

        builder.HasIndex(x => x.FiiiCode).IsUnique().HasDatabaseName("uq_cat_pais_1");
    }
}
