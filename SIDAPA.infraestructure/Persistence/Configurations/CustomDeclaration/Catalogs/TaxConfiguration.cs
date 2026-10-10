using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class TaxConfiguration : IEntityTypeConfiguration<TaxEntity>
{
    public void Configure(EntityTypeBuilder<TaxEntity> builder)
    {
        builder.ToTable("cat_contribucion");
        builder.HasKey(x => x.Code).HasName("pk_cat_contribucion");

        builder.Property(x => x.Code).HasColumnName("clave").ValueGeneratedNever();
        builder.Property(x => x.Description).HasColumnName("descripcion").HasMaxLength(200);
        builder.Property(x => x.Abbreviation).HasColumnName("abreviacion").HasMaxLength(10);
        builder.Property(x => x.Level).HasColumnName("nivel").HasMaxLength(3);
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");
    }
}
