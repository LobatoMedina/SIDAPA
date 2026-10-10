using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class UnitOfMeasureConfiguration : IEntityTypeConfiguration<UnitOfMeasureEntity>
{
    public void Configure(EntityTypeBuilder<UnitOfMeasureEntity> builder)
    {
        builder.ToTable("cat_unidad_medida");
        builder.HasKey(x => x.Code).HasName("pk_cat_unidad_medida");

        builder.Property(x => x.Code).HasColumnName("clave").HasMaxLength(2);
        builder.Property(x => x.Description).HasColumnName("descripcion").HasMaxLength(60);
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");
    }
}
