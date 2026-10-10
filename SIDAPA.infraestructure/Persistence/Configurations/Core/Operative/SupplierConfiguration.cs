using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Operative;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.Core.Operative;

public class SupplierConfiguration : IEntityTypeConfiguration<SupplierEntity>
{
    public void Configure(EntityTypeBuilder<SupplierEntity> builder)
    {
        builder.ToTable("ope_proveedor");
        builder.HasKey(x => x.Id).HasName("pk_ope_proveedor");

        builder.Property(x => x.Id).HasColumnName("id_proveedor").UseIdentityAlwaysColumn();
        builder.Property(x => x.Name).HasColumnName("nombre").HasMaxLength(150);
        builder.Property(x => x.TaxId).HasColumnName("id_fiscal").HasMaxLength(30);
        builder.Property(x => x.Address).HasColumnName("domicilio").HasMaxLength(250);
        builder.Property(x => x.CountryCode).HasColumnName("clave_pais").HasMaxLength(3).IsFixedLength();

        builder.HasOne(x => x.Country)
            .WithMany()
            .HasForeignKey(x => x.CountryCode)
            .HasConstraintName("fk_ope_proveedor_clave_pais")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
