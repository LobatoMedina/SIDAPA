using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class GoodsDestinationConfiguration : IEntityTypeConfiguration<GoodsDestinationEntity>
{
    public void Configure(EntityTypeBuilder<GoodsDestinationEntity> builder)
    {
        builder.ToTable("cat_destino_mercancia");
        builder.HasKey(x => x.Code).HasName("pk_cat_destino_mercancia");

        builder.Property(x => x.Code).HasColumnName("clave").HasMaxLength(2);
        builder.Property(x => x.Description).HasColumnName("descripcion").HasMaxLength(200);
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");
    }
}
