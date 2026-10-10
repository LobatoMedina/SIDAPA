using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class ValuationMethodConfiguration : IEntityTypeConfiguration<ValuationMethodEntity>
{
    public void Configure(EntityTypeBuilder<ValuationMethodEntity> builder)
    {
        builder.ToTable("cat_metodo_valoracion");
        builder.HasKey(x => x.Code).HasName("pk_cat_metodo_valoracion");

        builder.Property(x => x.Code).HasColumnName("clave").HasMaxLength(1).IsFixedLength();
        builder.Property(x => x.Description).HasColumnName("descripcion").HasMaxLength(150);
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");
    }
}
