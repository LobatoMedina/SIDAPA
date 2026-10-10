using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Operative;

public class PartidaPermitConfiguration : IEntityTypeConfiguration<PartidaPermitEntity>
{
    public void Configure(EntityTypeBuilder<PartidaPermitEntity> builder)
    {
        builder.ToTable("ope_permiso_partida");
        builder.HasKey(x => x.Id).HasName("pk_ope_permiso_partida");

        builder.Property(x => x.Id).HasColumnName("id_permiso").UseIdentityAlwaysColumn();
        builder.Property(x => x.PartidaId).HasColumnName("id_partida");
        builder.Property(x => x.RegulationId).HasColumnName("id_regulacion");
        builder.Property(x => x.PermitNumber).HasColumnName("numero_permiso").HasMaxLength(40);
        builder.Property(x => x.DischargeSignature).HasColumnName("firma_descargo").HasMaxLength(40);
        builder.Property(x => x.ValueInUsd).HasColumnName("valor_dolares").HasPrecision(16, 2);
        builder.Property(x => x.TariffQuantity).HasColumnName("cantidad_umt").HasPrecision(14, 3);

        builder.HasOne(x => x.Partida)
            .WithMany(x => x.Permits)
            .HasForeignKey(x => x.PartidaId)
            .HasConstraintName("fk_ope_permiso_partida_id_partida")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Regulation)
            .WithMany()
            .HasForeignKey(x => x.RegulationId)
            .HasConstraintName("fk_ope_permiso_partida_id_regulacion")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
