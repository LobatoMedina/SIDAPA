using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.Core.Catalogs;

public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable("cat_rol");
        builder.HasKey(x => x.Id).HasName("pk_cat_rol");

        builder.Property(x => x.Id).HasColumnName("id_rol").ValueGeneratedNever();
        builder.Property(x => x.Name).HasColumnName("nombre").HasMaxLength(30);

        builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName("uq_cat_rol_1");
    }
}
