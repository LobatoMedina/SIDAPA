using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class RateTypeConfiguration : IEntityTypeConfiguration<RateTypeEntity>
{
    public void Configure(EntityTypeBuilder<RateTypeEntity> builder)
    {
        builder.ToTable("cat_tipo_tasa");
        builder.HasKey(x => x.Code).HasName("pk_cat_tipo_tasa");

        builder.Property(x => x.Code).HasColumnName("clave").HasMaxLength(2);
        builder.Property(x => x.Description).HasColumnName("descripcion").HasMaxLength(150);
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");
    }
}
