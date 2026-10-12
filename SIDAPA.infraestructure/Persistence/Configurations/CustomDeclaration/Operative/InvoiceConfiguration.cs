using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Operative;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Operative;

public class InvoiceConfiguration : IEntityTypeConfiguration<InvoiceEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceEntity> builder)
    {
        builder.ToTable("ope_factura");
        builder.HasKey(x => x.Id).HasName("pk_ope_factura");

        builder.Property(x => x.Id).HasColumnName("id_factura").UseIdentityAlwaysColumn();
        builder.Property(x => x.ReferenciaId).HasColumnName("id_referencia");
        builder.Property(x => x.DocumentId).HasColumnName("id_documento");
        builder.Property(x => x.SupplierId).HasColumnName("id_proveedor");
        builder.Property(x => x.InvoiceNumber).HasColumnName("numero_factura").HasMaxLength(40);
        builder.Property(x => x.InvoiceDate).HasColumnName("fecha_factura");
        builder.Property(x => x.CurrencyCode).HasColumnName("clave_moneda").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.IncotermCode).HasColumnName("incoterm").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.ValueInCurrency).HasColumnName("valor_moneda").HasPrecision(16, 2);
        builder.Property(x => x.CurrencyFactor).HasColumnName("factor_moneda").HasPrecision(14, 8);
        builder.Property(x => x.ValueInUsd).HasColumnName("valor_dolares").HasPrecision(16, 2);
        builder.Property(x => x.ReadSource).HasColumnName("origen_lectura").HasMaxLength(10);
        builder.Property(x => x.IsConfirmed).HasColumnName("confirmada");

        builder.HasOne(x => x.Referencia)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.ReferenciaId)
            .HasConstraintName("fk_ope_factura_id_referencia")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Document)
            .WithMany()
            .HasForeignKey(x => x.DocumentId)
            .HasConstraintName("fk_ope_factura_id_documento")
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Supplier)
            .WithMany()
            .HasForeignKey(x => x.SupplierId)
            .HasConstraintName("fk_ope_factura_id_proveedor")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Currency)
            .WithMany()
            .HasForeignKey(x => x.CurrencyCode)
            .HasConstraintName("fk_ope_factura_clave_moneda")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Incoterm)
            .WithMany()
            .HasForeignKey(x => x.IncotermCode)
            .HasConstraintName("fk_ope_factura_incoterm")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
