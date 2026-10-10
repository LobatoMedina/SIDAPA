using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Operative;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Operative;

public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("ope_producto");
        builder.HasKey(x => x.Id).HasName("pk_ope_producto");

        builder.Property(x => x.Id).HasColumnName("id_producto").UseIdentityAlwaysColumn();
        builder.Property(x => x.ClientId).HasColumnName("id_cliente");
        builder.Property(x => x.PartNumber).HasColumnName("numero_parte").HasMaxLength(50);
        builder.Property(x => x.Description).HasColumnName("descripcion").HasMaxLength(300);
        builder.Property(x => x.FraccionArancelariaId).HasColumnName("id_fraccion");
        builder.Property(x => x.Status).HasColumnName("estado").HasMaxLength(12);
        builder.Property(x => x.GlosadorId).HasColumnName("id_glosador");
        builder.Property(x => x.ApprovedAt).HasColumnName("fecha_aprobacion").HasColumnType("timestamp without time zone");

        builder.HasOne(x => x.Client)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ClientId)
            .HasConstraintName("fk_ope_producto_id_cliente")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.FraccionArancelaria)
            .WithMany()
            .HasForeignKey(x => x.FraccionArancelariaId)
            .HasConstraintName("fk_ope_producto_id_fraccion")
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Glosador)
            .WithMany()
            .HasForeignKey(x => x.GlosadorId)
            .HasConstraintName("fk_ope_producto_id_glosador")
            .OnDelete(DeleteBehavior.SetNull);
    }
}
