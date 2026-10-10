using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class CustomsBrokerConfiguration : IEntityTypeConfiguration<CustomsBrokerEntity>
{
    public void Configure(EntityTypeBuilder<CustomsBrokerEntity> builder)
    {
        builder.ToTable("cat_agente_aduanal");
        builder.HasKey(x => x.Patente).HasName("pk_cat_agente_aduanal");

        builder.Property(x => x.Patente).HasColumnName("patente").HasMaxLength(4).IsFixedLength();
        builder.Property(x => x.Name).HasColumnName("nombre").HasMaxLength(150);
        builder.Property(x => x.Rfc).HasColumnName("rfc").HasMaxLength(13);
        builder.Property(x => x.Type).HasColumnName("tipo").HasMaxLength(10);
        builder.Property(x => x.AduanaCode).HasColumnName("clave_aduana").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.IsActive).HasColumnName("activo");

        builder.HasOne(x => x.Aduana)
            .WithMany()
            .HasForeignKey(x => x.AduanaCode)
            .HasConstraintName("fk_cat_agente_aduanal_clave_aduana")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
