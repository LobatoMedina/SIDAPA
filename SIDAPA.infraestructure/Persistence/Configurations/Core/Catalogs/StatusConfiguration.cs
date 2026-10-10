using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.Core.Catalogs;

public class StatusConfiguration : IEntityTypeConfiguration<StatusEntity>
{
    public void Configure(EntityTypeBuilder<StatusEntity> builder)
    {
        builder.ToTable("cat_estatus");
        builder.HasKey(x => x.Id).HasName("pk_cat_estatus");

        builder.Property(x => x.Id).HasColumnName("id_estatus").ValueGeneratedNever();
        builder.Property(x => x.Name).HasColumnName("nombre").HasMaxLength(40);
        builder.Property(x => x.SortOrder).HasColumnName("orden");

        builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName("uq_cat_estatus_1");
    }
}
