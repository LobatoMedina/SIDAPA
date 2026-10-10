using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Operative;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Operative;

public class AnnotationConfiguration : IEntityTypeConfiguration<AnnotationEntity>
{
    public void Configure(EntityTypeBuilder<AnnotationEntity> builder)
    {
        builder.ToTable("ope_anotacion");
        builder.HasKey(x => x.Id).HasName("pk_ope_anotacion");

        builder.Property(x => x.Id).HasColumnName("id_anotacion").UseIdentityAlwaysColumn();
        builder.Property(x => x.PedimentoId).HasColumnName("id_pedimento");
        builder.Property(x => x.PartidaId).HasColumnName("id_partida");
        builder.Property(x => x.Field).HasColumnName("campo").HasMaxLength(60);
        builder.Property(x => x.Comment).HasColumnName("comentario").HasMaxLength(500);
        builder.Property(x => x.Status).HasColumnName("estado").HasMaxLength(12);
        builder.Property(x => x.GlosadorId).HasColumnName("id_glosador");
        builder.Property(x => x.CreatedAt).HasColumnName("fecha").HasColumnType("timestamp without time zone");

        builder.HasOne(x => x.Pedimento)
            .WithMany(x => x.Annotations)
            .HasForeignKey(x => x.PedimentoId)
            .HasConstraintName("fk_ope_anotacion_id_pedimento")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Partida)
            .WithMany(x => x.Annotations)
            .HasForeignKey(x => x.PartidaId)
            .HasConstraintName("fk_ope_anotacion_id_partida")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Glosador)
            .WithMany()
            .HasForeignKey(x => x.GlosadorId)
            .HasConstraintName("fk_ope_anotacion_id_glosador")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
