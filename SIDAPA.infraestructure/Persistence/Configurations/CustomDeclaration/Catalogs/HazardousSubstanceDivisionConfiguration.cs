using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class HazardousSubstanceDivisionConfiguration : IEntityTypeConfiguration<HazardousSubstanceDivisionEntity>
{
    public void Configure(EntityTypeBuilder<HazardousSubstanceDivisionEntity> builder)
    {
        builder.ToTable("cat_division_sustancia_peligrosa");
        builder.HasKey(x => x.Code).HasName("pk_cat_division_sustancia_peligrosa");

        builder.Property(x => x.Code).HasColumnName("division").HasMaxLength(3);
        builder.Property(x => x.ClassCode).HasColumnName("clase").HasMaxLength(1).IsFixedLength();
        builder.Property(x => x.Description).HasColumnName("descripcion");

        builder.HasOne(x => x.SubstanceClass)
            .WithMany(x => x.Divisions)
            .HasForeignKey(x => x.ClassCode)
            .HasConstraintName("fk_cat_division_sustancia_peligrosa_clase")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
