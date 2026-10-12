using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Operative;

public class InvoiceLineConfiguration : IEntityTypeConfiguration<InvoiceLineEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceLineEntity> builder)
    {
        builder.ToTable("ope_renglon_factura");
        builder.HasKey(x => x.Id).HasName("pk_ope_renglon_factura");

        builder.Property(x => x.Id).HasColumnName("id_renglon").UseIdentityAlwaysColumn();
        builder.Property(x => x.InvoiceId).HasColumnName("id_factura");
        builder.Property(x => x.PartNumber).HasColumnName("numero_parte").HasMaxLength(50);
        builder.Property(x => x.Description).HasColumnName("descripcion").HasMaxLength(300);
        builder.Property(x => x.Quantity).HasColumnName("cantidad").HasPrecision(14, 3);
        builder.Property(x => x.UnitCode).HasColumnName("clave_unidad").HasMaxLength(2);
        builder.Property(x => x.UnitPrice).HasColumnName("precio_unitario").HasPrecision(16, 5);
        builder.Property(x => x.Amount).HasColumnName("importe").HasPrecision(16, 2);
        builder.Property(x => x.OriginCountryCode).HasColumnName("clave_pais_origen").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.Confidence).HasColumnName("confianza").HasPrecision(5, 2);
        builder.Property(x => x.ProductId).HasColumnName("id_producto");

        builder.HasOne(x => x.Invoice)
            .WithMany(x => x.Lines)
            .HasForeignKey(x => x.InvoiceId)
            .HasConstraintName("fk_ope_renglon_factura_id_factura")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Unit)
            .WithMany()
            .HasForeignKey(x => x.UnitCode)
            .HasConstraintName("fk_ope_renglon_factura_clave_unidad")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.OriginCountry)
            .WithMany()
            .HasForeignKey(x => x.OriginCountryCode)
            .HasConstraintName("fk_ope_renglon_factura_clave_pais_origen")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId)
            .HasConstraintName("fk_ope_renglon_factura_id_producto")
            .OnDelete(DeleteBehavior.SetNull);
    }
}
