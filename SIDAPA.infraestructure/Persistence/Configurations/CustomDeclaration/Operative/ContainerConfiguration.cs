using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Operative;

public class ContainerConfiguration : IEntityTypeConfiguration<ContainerEntity>
{
    public void Configure(EntityTypeBuilder<ContainerEntity> builder)
    {
        builder.ToTable("ope_contenedor");
        builder.HasKey(x => x.Id).HasName("pk_ope_contenedor");

        builder.Property(x => x.Id).HasColumnName("id_contenedor").UseIdentityAlwaysColumn();
        builder.Property(x => x.PedimentoId).HasColumnName("id_pedimento");
        builder.Property(x => x.Number).HasColumnName("numero").HasMaxLength(11).IsFixedLength();
        builder.Property(x => x.ContainerTypeCode).HasColumnName("clave_tipo").HasMaxLength(2);
        builder.Property(x => x.Seals).HasColumnName("candados").HasMaxLength(100);

        builder.HasOne(x => x.Pedimento)
            .WithMany(x => x.Containers)
            .HasForeignKey(x => x.PedimentoId)
            .HasConstraintName("fk_ope_contenedor_id_pedimento")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.ContainerType)
            .WithMany()
            .HasForeignKey(x => x.ContainerTypeCode)
            .HasConstraintName("fk_ope_contenedor_clave_tipo")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
