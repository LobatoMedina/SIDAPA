using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Catalogs;
using SIDAPA.domain.Entities.Core.Operative;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.Core.Operative;

public class ReferenciaConfiguration : IEntityTypeConfiguration<ReferenciaEntity>
{
    public void Configure(EntityTypeBuilder<ReferenciaEntity> builder)
    {
        builder.ToTable("ope_referencia");
        builder.HasKey(x => x.Id).HasName("pk_ope_referencia");

        builder.Property(x => x.Id).HasColumnName("id_referencia").UseIdentityAlwaysColumn();
        builder.Property(x => x.ReferenciaNumber).HasColumnName("numero_referencia").HasMaxLength(20);
        builder.Property(x => x.ClientId).HasColumnName("id_cliente");
        builder.Property(x => x.CapturadorId).HasColumnName("id_capturador");
        builder.Property(x => x.OperationTypeCode).HasColumnName("tipo_operacion");
        builder.Property(x => x.AduanaCode).HasColumnName("clave_aduana").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.MasterBillOfLading).HasColumnName("bl_master").HasMaxLength(30);
        builder.Property(x => x.ArrivalDate).HasColumnName("fecha_arribo");
        builder.Property(x => x.Notes).HasColumnName("observaciones").HasMaxLength(500);
        builder.Property(x => x.StatusId).HasColumnName("id_estatus");
        builder.Property(x => x.CreatedAt).HasColumnName("fecha_creacion").HasColumnType("timestamp without time zone");

        builder.HasIndex(x => x.ReferenciaNumber).IsUnique().HasDatabaseName("uq_ope_referencia_1");

        builder.HasOne(x => x.Client)
            .WithMany(x => x.Referencias)
            .HasForeignKey(x => x.ClientId)
            .HasConstraintName("fk_ope_referencia_id_cliente")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Capturador)
            .WithMany()
            .HasForeignKey(x => x.CapturadorId)
            .HasConstraintName("fk_ope_referencia_id_capturador")
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.OperationType)
            .WithMany()
            .HasForeignKey(x => x.OperationTypeCode)
            .HasConstraintName("fk_ope_referencia_tipo_operacion")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Aduana)
            .WithMany()
            .HasForeignKey(x => x.AduanaCode)
            .HasConstraintName("fk_ope_referencia_clave_aduana")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.StatusId)
            .HasConstraintName("fk_ope_referencia_id_estatus")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
