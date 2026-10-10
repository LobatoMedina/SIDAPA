using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class RegulationConfiguration : IEntityTypeConfiguration<RegulationEntity>
{
    public void Configure(EntityTypeBuilder<RegulationEntity> builder)
    {
        builder.ToTable("cat_regulacion");
        builder.HasKey(x => x.Id).HasName("pk_cat_regulacion");

        builder.Property(x => x.Id).HasColumnName("id_regulacion").UseIdentityAlwaysColumn();
        builder.Property(x => x.GovernmentAgencyId).HasColumnName("id_dependencia");
        builder.Property(x => x.Code).HasColumnName("clave").HasMaxLength(2).IsFixedLength();
        builder.Property(x => x.Description).HasColumnName("descripcion");
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");

        builder.HasIndex(x => new { x.GovernmentAgencyId, x.Code }).IsUnique().HasDatabaseName("uq_cat_regulacion_1");

        builder.HasOne(x => x.GovernmentAgency)
            .WithMany(x => x.Regulations)
            .HasForeignKey(x => x.GovernmentAgencyId)
            .HasConstraintName("fk_cat_regulacion_id_dependencia")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
