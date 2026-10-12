using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class RfeConfiguration : IEntityTypeConfiguration<RfeEntity>
{
    public void Configure(EntityTypeBuilder<RfeEntity> builder)
    {
        builder.ToTable("cat_rfe");
        builder.HasKey(x => x.Code).HasName("pk_cat_rfe");

        builder.Property(x => x.Code).HasColumnName("clave_rfe").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.AduanaName).HasColumnName("aduana").HasMaxLength(80);
        builder.Property(x => x.Administrator).HasColumnName("administrador").HasMaxLength(200);
        builder.Property(x => x.IsAdjacent).HasColumnName("colindante");
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");
    }
}
