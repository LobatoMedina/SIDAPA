using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Operative;

public class WaybillConfiguration : IEntityTypeConfiguration<WaybillEntity>
{
    public void Configure(EntityTypeBuilder<WaybillEntity> builder)
    {
        builder.ToTable("ope_guia");
        builder.HasKey(x => x.Id).HasName("pk_ope_guia");

        builder.Property(x => x.Id).HasColumnName("id_guia").UseIdentityAlwaysColumn();
        builder.Property(x => x.PedimentoId).HasColumnName("id_pedimento");
        builder.Property(x => x.Number).HasColumnName("numero").HasMaxLength(30);
        builder.Property(x => x.Type).HasColumnName("tipo").HasMaxLength(1).IsFixedLength();

        builder.HasOne(x => x.Pedimento)
            .WithMany(x => x.Waybills)
            .HasForeignKey(x => x.PedimentoId)
            .HasConstraintName("fk_ope_guia_id_pedimento")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
