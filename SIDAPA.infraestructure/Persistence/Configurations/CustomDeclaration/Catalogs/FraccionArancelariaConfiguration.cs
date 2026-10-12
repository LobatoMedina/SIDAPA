using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class FraccionArancelariaConfiguration : IEntityTypeConfiguration<FraccionArancelariaEntity>
{
    public void Configure(EntityTypeBuilder<FraccionArancelariaEntity> builder)
    {
        builder.ToTable("cat_fraccion_arancelaria");
        builder.HasKey(x => x.Id).HasName("pk_cat_fraccion_arancelaria");

        builder.Property(x => x.Id).HasColumnName("id_fraccion").UseIdentityAlwaysColumn();
        builder.Property(x => x.Fraccion).HasColumnName("fraccion").HasMaxLength(8).IsFixedLength();
        builder.Property(x => x.Nico).HasColumnName("nico").HasMaxLength(2).IsFixedLength();
        builder.Property(x => x.Description).HasColumnName("descripcion");
        builder.Property(x => x.TariffUnitCode).HasColumnName("clave_unidad_tarifa").HasMaxLength(2);
        builder.Property(x => x.ImportDutyRate).HasColumnName("tasa_igi").HasPrecision(7, 4);
        builder.Property(x => x.ExportDutyRate).HasColumnName("tasa_ige").HasPrecision(7, 4);
        builder.Property(x => x.ValidFrom).HasColumnName("vigente_desde");
        builder.Property(x => x.ValidTo).HasColumnName("vigente_hasta");

        builder.HasIndex(x => new { x.Fraccion, x.Nico }).IsUnique().HasDatabaseName("uq_cat_fraccion_arancelaria_1");

        builder.HasOne(x => x.TariffUnit)
            .WithMany()
            .HasForeignKey(x => x.TariffUnitCode)
            .HasConstraintName("fk_cat_fraccion_arancelaria_clave_unidad_tarifa")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
