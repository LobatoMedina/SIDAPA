using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Operative;

public class PartidaIdentificadorConfiguration : IEntityTypeConfiguration<PartidaIdentificadorEntity>
{
    public void Configure(EntityTypeBuilder<PartidaIdentificadorEntity> builder)
    {
        builder.ToTable("ope_identificador_partida");
        builder.HasKey(x => x.Id).HasName("pk_ope_identificador_partida");

        builder.Property(x => x.Id).HasColumnName("id_identificador_partida").UseIdentityAlwaysColumn();
        builder.Property(x => x.PartidaId).HasColumnName("id_partida");
        builder.Property(x => x.IdentificadorId).HasColumnName("id_identificador");
        builder.Property(x => x.Complement1).HasColumnName("complemento1").HasMaxLength(40);
        builder.Property(x => x.Complement2).HasColumnName("complemento2").HasMaxLength(40);
        builder.Property(x => x.Complement3).HasColumnName("complemento3").HasMaxLength(40);

        builder.HasOne(x => x.Partida)
            .WithMany(x => x.Identificadores)
            .HasForeignKey(x => x.PartidaId)
            .HasConstraintName("fk_ope_identificador_partida_id_partida")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Identificador)
            .WithMany()
            .HasForeignKey(x => x.IdentificadorId)
            .HasConstraintName("fk_ope_identificador_partida_id_identificador")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
