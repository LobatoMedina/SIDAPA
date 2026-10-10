using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Catalogs;
using SIDAPA.domain.Entities.Core.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.Core.Operative;

public class StatusHistoryConfiguration : IEntityTypeConfiguration<StatusHistoryEntity>
{
    public void Configure(EntityTypeBuilder<StatusHistoryEntity> builder)
    {
        builder.ToTable("ope_bitacora_estatus");
        builder.HasKey(x => x.Id).HasName("pk_ope_bitacora_estatus");

        builder.Property(x => x.Id).HasColumnName("id_bitacora").UseIdentityAlwaysColumn();
        builder.Property(x => x.ReferenciaId).HasColumnName("id_referencia");
        builder.Property(x => x.StatusId).HasColumnName("id_estatus");
        builder.Property(x => x.UserId).HasColumnName("id_usuario");
        builder.Property(x => x.ChangedAt).HasColumnName("fecha").HasColumnType("timestamp without time zone");
        builder.Property(x => x.Comment).HasColumnName("comentario").HasMaxLength(300);

        builder.HasOne(x => x.Referencia)
            .WithMany(x => x.StatusHistories)
            .HasForeignKey(x => x.ReferenciaId)
            .HasConstraintName("fk_ope_bitacora_estatus_id_referencia")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.StatusId)
            .HasConstraintName("fk_ope_bitacora_estatus_id_estatus")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .HasConstraintName("fk_ope_bitacora_estatus_id_usuario")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
