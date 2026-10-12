using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Operative;

public class ValidationFileConfiguration : IEntityTypeConfiguration<ValidationFileEntity>
{
    public void Configure(EntityTypeBuilder<ValidationFileEntity> builder)
    {
        builder.ToTable("ope_archivo_validacion");
        builder.HasKey(x => x.Id).HasName("pk_ope_archivo_validacion");

        builder.Property(x => x.Id).HasColumnName("id_archivo").UseIdentityAlwaysColumn();
        builder.Property(x => x.PedimentoId).HasColumnName("id_pedimento");
        builder.Property(x => x.FileName).HasColumnName("nombre_archivo").HasMaxLength(20);
        builder.Property(x => x.BucketPath).HasColumnName("ruta_bucket").HasMaxLength(300);
        builder.Property(x => x.GeneratedAt).HasColumnName("fecha_generacion").HasColumnType("timestamp without time zone");
        builder.Property(x => x.Result).HasColumnName("resultado").HasMaxLength(12);
        builder.Property(x => x.Acknowledgment).HasColumnName("acuse").HasMaxLength(8);
        builder.Property(x => x.ResponseDetail).HasColumnName("detalle_respuesta");

        builder.HasOne(x => x.Pedimento)
            .WithMany(x => x.ValidationFiles)
            .HasForeignKey(x => x.PedimentoId)
            .HasConstraintName("fk_ope_archivo_validacion_id_pedimento")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
