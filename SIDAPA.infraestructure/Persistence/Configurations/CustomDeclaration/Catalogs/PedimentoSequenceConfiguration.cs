using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class PedimentoSequenceConfiguration : IEntityTypeConfiguration<PedimentoSequenceEntity>
{
    public void Configure(EntityTypeBuilder<PedimentoSequenceEntity> builder)
    {
        builder.ToTable("cat_consecutivo_pedimento");
        builder.HasKey(x => x.Id).HasName("pk_cat_consecutivo_pedimento");

        builder.Property(x => x.Id).HasColumnName("id_consecutivo").UseIdentityAlwaysColumn();
        builder.Property(x => x.Patente).HasColumnName("patente").HasMaxLength(4).IsFixedLength();
        builder.Property(x => x.AduanaCode).HasColumnName("clave_aduana").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.Year).HasColumnName("anio");
        builder.Property(x => x.LastSequence).HasColumnName("ultimo_consecutivo");

        builder.HasIndex(x => new { x.Patente, x.AduanaCode, x.Year }).IsUnique().HasDatabaseName("uq_cat_consecutivo_pedimento_1");

        builder.HasOne(x => x.CustomsBroker)
            .WithMany()
            .HasForeignKey(x => x.Patente)
            .HasConstraintName("fk_cat_consecutivo_pedimento_patente")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Aduana)
            .WithMany()
            .HasForeignKey(x => x.AduanaCode)
            .HasConstraintName("fk_cat_consecutivo_pedimento_clave_aduana")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
