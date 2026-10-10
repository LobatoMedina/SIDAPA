using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Catalogs;
using SIDAPA.domain.Entities.Core.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.Core.Operative;

public class DocumentConfiguration : IEntityTypeConfiguration<DocumentEntity>
{
    public void Configure(EntityTypeBuilder<DocumentEntity> builder)
    {
        builder.ToTable("ope_documento");
        builder.HasKey(x => x.Id).HasName("pk_ope_documento");

        builder.Property(x => x.Id).HasColumnName("id_documento").UseIdentityAlwaysColumn();
        builder.Property(x => x.ReferenciaId).HasColumnName("id_referencia");
        builder.Property(x => x.DocumentTypeId).HasColumnName("id_tipo_documento");
        builder.Property(x => x.FileName).HasColumnName("nombre_archivo").HasMaxLength(200);
        builder.Property(x => x.BucketPath).HasColumnName("ruta_bucket").HasMaxLength(300);
        builder.Property(x => x.SizeInBytes).HasColumnName("tamano_bytes");
        builder.Property(x => x.Status).HasColumnName("estado").HasMaxLength(15);
        builder.Property(x => x.Note).HasColumnName("nota").HasMaxLength(300);
        builder.Property(x => x.UploadedByUserId).HasColumnName("id_usuario_carga");
        builder.Property(x => x.UploadedAt).HasColumnName("fecha_carga").HasColumnType("timestamp without time zone");

        builder.HasOne(x => x.Referencia)
            .WithMany(x => x.Documents)
            .HasForeignKey(x => x.ReferenciaId)
            .HasConstraintName("fk_ope_documento_id_referencia")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.DocumentType)
            .WithMany()
            .HasForeignKey(x => x.DocumentTypeId)
            .HasConstraintName("fk_ope_documento_id_tipo_documento")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.UploadedByUser)
            .WithMany()
            .HasForeignKey(x => x.UploadedByUserId)
            .HasConstraintName("fk_ope_documento_id_usuario_carga")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
