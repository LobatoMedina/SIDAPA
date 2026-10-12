using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class PedimentoKeyConfiguration : IEntityTypeConfiguration<PedimentoKeyEntity>
{
    public void Configure(EntityTypeBuilder<PedimentoKeyEntity> builder)
    {
        builder.ToTable("cat_clave_pedimento");
        builder.HasKey(x => x.Code).HasName("pk_cat_clave_pedimento");

        builder.Property(x => x.Code).HasColumnName("clave").HasMaxLength(2).IsFixedLength();
        builder.Property(x => x.Description).HasColumnName("descripcion").HasMaxLength(200);
        builder.Property(x => x.Group).HasColumnName("grupo").HasMaxLength(60);
        builder.Property(x => x.Subgroup).HasColumnName("subgrupo").HasMaxLength(60);
        builder.Property(x => x.ApplicationCases).HasColumnName("supuestos_aplicacion");
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");
    }
}
