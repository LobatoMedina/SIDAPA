using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.Core.Operative;

public class NotificationConfiguration : IEntityTypeConfiguration<NotificationEntity>
{
    public void Configure(EntityTypeBuilder<NotificationEntity> builder)
    {
        builder.ToTable("ope_notificacion");
        builder.HasKey(x => x.Id).HasName("pk_ope_notificacion");

        builder.Property(x => x.Id).HasColumnName("id_notificacion").UseIdentityAlwaysColumn();
        builder.Property(x => x.UserId).HasColumnName("id_usuario");
        builder.Property(x => x.ReferenciaId).HasColumnName("id_referencia");
        builder.Property(x => x.Message).HasColumnName("mensaje").HasMaxLength(500);
        builder.Property(x => x.IsRead).HasColumnName("leida");
        builder.Property(x => x.IsEmailSent).HasColumnName("enviada_correo");
        builder.Property(x => x.CreatedAt).HasColumnName("fecha").HasColumnType("timestamp without time zone");

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .HasConstraintName("fk_ope_notificacion_id_usuario")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Referencia)
            .WithMany(x => x.Notifications)
            .HasForeignKey(x => x.ReferenciaId)
            .HasConstraintName("fk_ope_notificacion_id_referencia")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
