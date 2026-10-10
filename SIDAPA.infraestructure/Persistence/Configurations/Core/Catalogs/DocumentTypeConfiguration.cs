using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.Core.Catalogs;

public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentTypeEntity>
{
    public void Configure(EntityTypeBuilder<DocumentTypeEntity> builder)
    {
        builder.ToTable("cat_tipo_documento");
        builder.HasKey(x => x.Id).HasName("pk_cat_tipo_documento");

        builder.Property(x => x.Id).HasColumnName("id_tipo_documento").ValueGeneratedNever();
        builder.Property(x => x.Name).HasColumnName("nombre").HasMaxLength(60);

        builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName("uq_cat_tipo_documento_1");
    }
}
