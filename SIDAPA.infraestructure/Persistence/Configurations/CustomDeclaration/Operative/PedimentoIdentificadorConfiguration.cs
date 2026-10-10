using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Operative;

public class PedimentoIdentificadorConfiguration : IEntityTypeConfiguration<PedimentoIdentificadorEntity>
{
    public void Configure(EntityTypeBuilder<PedimentoIdentificadorEntity> builder)
    {
        builder.ToTable("ope_identificador_pedimento");
        builder.HasKey(x => x.Id).HasName("pk_ope_identificador_pedimento");

        builder.Property(x => x.Id).HasColumnName("id_identificador_ped").UseIdentityAlwaysColumn();
        builder.Property(x => x.PedimentoId).HasColumnName("id_pedimento");
        builder.Property(x => x.IdentificadorId).HasColumnName("id_identificador");
        builder.Property(x => x.Complement1).HasColumnName("complemento1").HasMaxLength(40);
        builder.Property(x => x.Complement2).HasColumnName("complemento2").HasMaxLength(40);
        builder.Property(x => x.Complement3).HasColumnName("complemento3").HasMaxLength(40);

        builder.HasOne(x => x.Pedimento)
            .WithMany(x => x.Identificadores)
            .HasForeignKey(x => x.PedimentoId)
            .HasConstraintName("fk_ope_identificador_pedimento_id_pedimento")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Identificador)
            .WithMany()
            .HasForeignKey(x => x.IdentificadorId)
            .HasConstraintName("fk_ope_identificador_pedimento_id_identificador")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
