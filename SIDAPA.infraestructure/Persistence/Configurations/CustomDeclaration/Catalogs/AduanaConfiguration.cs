using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class AduanaConfiguration : IEntityTypeConfiguration<AduanaEntity>
{
    public void Configure(EntityTypeBuilder<AduanaEntity> builder)
    {
        builder.ToTable("cat_aduana_seccion");
        builder.HasKey(x => x.Code).HasName("pk_cat_aduana_seccion");

        builder.Property(x => x.Code).HasColumnName("clave").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.AduanaCode).HasColumnName("clave_aduana").HasMaxLength(2).IsFixedLength();
        builder.Property(x => x.Section).HasColumnName("seccion").HasMaxLength(1).IsFixedLength();
        builder.Property(x => x.Name).HasColumnName("denominacion").HasMaxLength(200);
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");
    }
}
