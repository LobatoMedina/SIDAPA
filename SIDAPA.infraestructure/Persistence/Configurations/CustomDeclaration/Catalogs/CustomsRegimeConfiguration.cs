using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class CustomsRegimeConfiguration : IEntityTypeConfiguration<CustomsRegimeEntity>
{
    public void Configure(EntityTypeBuilder<CustomsRegimeEntity> builder)
    {
        builder.ToTable("cat_regimen");
        builder.HasKey(x => x.Code).HasName("pk_cat_regimen");

        builder.Property(x => x.Code).HasColumnName("clave").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.Description).HasColumnName("descripcion").HasMaxLength(150);
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");
    }
}
