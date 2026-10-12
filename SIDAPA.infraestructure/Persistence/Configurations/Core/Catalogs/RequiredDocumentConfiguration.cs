using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Catalogs;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.Core.Catalogs;

public class RequiredDocumentConfiguration : IEntityTypeConfiguration<RequiredDocumentEntity>
{
    public void Configure(EntityTypeBuilder<RequiredDocumentEntity> builder)
    {
        builder.ToTable("cat_documento_requerido");
        builder.HasKey(x => x.Id).HasName("pk_cat_documento_requerido");

        builder.Property(x => x.Id).HasColumnName("id_documento_requerido").UseIdentityAlwaysColumn();
        builder.Property(x => x.OperationTypeCode).HasColumnName("tipo_operacion");
        builder.Property(x => x.PedimentoKeyCode).HasColumnName("clave_pedimento").HasMaxLength(2).IsFixedLength();
        builder.Property(x => x.DocumentTypeId).HasColumnName("id_tipo_documento");
        builder.Property(x => x.IsMandatory).HasColumnName("obligatorio");

        builder.HasOne(x => x.OperationType)
            .WithMany()
            .HasForeignKey(x => x.OperationTypeCode)
            .HasConstraintName("fk_cat_documento_requerido_tipo_operacion")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PedimentoKey)
            .WithMany()
            .HasForeignKey(x => x.PedimentoKeyCode)
            .HasConstraintName("fk_cat_documento_requerido_clave_pedimento")
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.DocumentType)
            .WithMany()
            .HasForeignKey(x => x.DocumentTypeId)
            .HasConstraintName("fk_cat_documento_requerido_id_tipo_documento")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
