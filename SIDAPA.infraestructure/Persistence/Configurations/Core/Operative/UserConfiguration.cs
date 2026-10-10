using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Catalogs;
using SIDAPA.domain.Entities.Core.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.Core.Operative;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("ope_usuario");
        builder.HasKey(x => x.Id).HasName("pk_ope_usuario");

        builder.Property(x => x.Id).HasColumnName("id_usuario").UseIdentityAlwaysColumn();
        builder.Property(x => x.Name).HasColumnName("nombre").HasMaxLength(100);
        builder.Property(x => x.Email).HasColumnName("correo").HasMaxLength(120);
        builder.Property(x => x.PasswordHash).HasColumnName("contrasena_hash").HasMaxLength(255);
        builder.Property(x => x.RoleId).HasColumnName("id_rol");
        builder.Property(x => x.ClientId).HasColumnName("id_cliente");
        builder.Property(x => x.FailedLoginAttempts).HasColumnName("intentos_fallidos");
        builder.Property(x => x.LockedUntil).HasColumnName("bloqueado_hasta").HasColumnType("timestamp without time zone");
        builder.Property(x => x.IsActive).HasColumnName("activo");

        builder.HasIndex(x => x.Email).IsUnique().HasDatabaseName("uq_ope_usuario_1");

        builder.HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.RoleId)
            .HasConstraintName("fk_ope_usuario_id_rol")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Client)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.ClientId)
            .HasConstraintName("fk_ope_usuario_id_cliente")
            .OnDelete(DeleteBehavior.SetNull);
    }
}
