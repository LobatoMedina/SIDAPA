using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Catalogs;
using SIDAPA.domain.Entities.Core.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.Core.Operative;

public class DocumentRequestConfiguration : IEntityTypeConfiguration<DocumentRequestEntity>
{
    public void Configure(EntityTypeBuilder<DocumentRequestEntity> builder)
    {
        builder.ToTable("ope_solicitud_documento");
        builder.HasKey(x => x.Id).HasName("pk_ope_solicitud_documento");

        builder.Property(x => x.Id).HasColumnName("id_solicitud").UseIdentityAlwaysColumn();
        builder.Property(x => x.ReferenciaId).HasColumnName("id_referencia");
        builder.Property(x => x.DocumentTypeId).HasColumnName("id_tipo_documento");
        builder.Property(x => x.Note).HasColumnName("nota").HasMaxLength(500);
        builder.Property(x => x.RequestedByUserId).HasColumnName("id_capturador");
        builder.Property(x => x.RequestedAt).HasColumnName("fecha_solicitud").HasColumnType("timestamp without time zone");
        builder.Property(x => x.ResponseDocumentId).HasColumnName("id_documento_respuesta");
        builder.Property(x => x.AttendedAt).HasColumnName("fecha_atencion").HasColumnType("timestamp without time zone");

        builder.HasOne(x => x.Referencia)
            .WithMany(x => x.DocumentRequests)
            .HasForeignKey(x => x.ReferenciaId)
            .HasConstraintName("fk_ope_solicitud_documento_id_referencia")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.DocumentType)
            .WithMany()
            .HasForeignKey(x => x.DocumentTypeId)
            .HasConstraintName("fk_ope_solicitud_documento_id_tipo_documento")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.RequestedByUser)
            .WithMany()
            .HasForeignKey(x => x.RequestedByUserId)
            .HasConstraintName("fk_ope_solicitud_documento_id_capturador")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ResponseDocument)
            .WithMany()
            .HasForeignKey(x => x.ResponseDocumentId)
            .HasConstraintName("fk_ope_solicitud_documento_id_documento_respuesta")
            .OnDelete(DeleteBehavior.SetNull);
    }
}
