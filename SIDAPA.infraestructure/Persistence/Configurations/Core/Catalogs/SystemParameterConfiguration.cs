using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.Core.Catalogs;

public class SystemParameterConfiguration : IEntityTypeConfiguration<SystemParameterEntity>
{
    public void Configure(EntityTypeBuilder<SystemParameterEntity> builder)
    {
        builder.ToTable("cat_parametro");
        builder.HasKey(x => x.Key).HasName("pk_cat_parametro");

        builder.Property(x => x.Key).HasColumnName("clave").HasMaxLength(40);
        builder.Property(x => x.Value).HasColumnName("valor").HasMaxLength(100);
        builder.Property(x => x.ValidFrom).HasColumnName("vigente_desde");
        builder.Property(x => x.Description).HasColumnName("descripcion").HasMaxLength(200);
    }
}
