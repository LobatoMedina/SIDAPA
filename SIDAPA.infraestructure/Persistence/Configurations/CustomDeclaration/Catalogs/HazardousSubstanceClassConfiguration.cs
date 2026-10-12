using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class HazardousSubstanceClassConfiguration : IEntityTypeConfiguration<HazardousSubstanceClassEntity>
{
    public void Configure(EntityTypeBuilder<HazardousSubstanceClassEntity> builder)
    {
        builder.ToTable("cat_clase_sustancia_peligrosa");
        builder.HasKey(x => x.Code).HasName("pk_cat_clase_sustancia_peligrosa");

        builder.Property(x => x.Code).HasColumnName("clase").HasMaxLength(1).IsFixedLength();
        builder.Property(x => x.Name).HasColumnName("denominacion").HasMaxLength(120);
        builder.Property(x => x.Definition).HasColumnName("definicion");
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");
    }
}
