using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class TransportModeConfiguration : IEntityTypeConfiguration<TransportModeEntity>
{
    public void Configure(EntityTypeBuilder<TransportModeEntity> builder)
    {
        builder.ToTable("cat_medio_transporte");
        builder.HasKey(x => x.Code).HasName("pk_cat_medio_transporte");

        builder.Property(x => x.Code).HasColumnName("clave").HasMaxLength(2);
        builder.Property(x => x.Description).HasColumnName("descripcion").HasMaxLength(100);
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");
    }
}
