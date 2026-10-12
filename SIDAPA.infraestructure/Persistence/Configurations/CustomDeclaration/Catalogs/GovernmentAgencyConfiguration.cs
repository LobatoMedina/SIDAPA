using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class GovernmentAgencyConfiguration : IEntityTypeConfiguration<GovernmentAgencyEntity>
{
    public void Configure(EntityTypeBuilder<GovernmentAgencyEntity> builder)
    {
        builder.ToTable("cat_dependencia");
        builder.HasKey(x => x.Id).HasName("pk_cat_dependencia");

        builder.Property(x => x.Id).HasColumnName("id_dependencia").ValueGeneratedNever();
        builder.Property(x => x.Name).HasColumnName("nombre").HasMaxLength(120);

        builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName("uq_cat_dependencia_1");
    }
}
