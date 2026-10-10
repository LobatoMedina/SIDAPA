using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class IncotermConfiguration : IEntityTypeConfiguration<IncotermEntity>
{
    public void Configure(EntityTypeBuilder<IncotermEntity> builder)
    {
        builder.ToTable("cat_incoterm");
        builder.HasKey(x => x.Code).HasName("pk_cat_incoterm");

        builder.Property(x => x.Code).HasColumnName("clave").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.Description).HasColumnName("descripcion").HasMaxLength(150);
        builder.Property(x => x.Group).HasColumnName("grupo").HasMaxLength(60);
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");
    }
}
