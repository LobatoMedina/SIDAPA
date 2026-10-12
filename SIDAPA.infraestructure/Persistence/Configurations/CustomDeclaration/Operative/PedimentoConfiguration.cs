using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Catalogs;
using SIDAPA.domain.Entities.Core.Operative;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Operative;

public class PedimentoConfiguration : IEntityTypeConfiguration<PedimentoEntity>
{
    public void Configure(EntityTypeBuilder<PedimentoEntity> builder)
    {
        builder.ToTable("ope_pedimento");
        builder.HasKey(x => x.Id).HasName("pk_ope_pedimento");

        builder.Property(x => x.Id).HasColumnName("id_pedimento").UseIdentityAlwaysColumn();
        builder.Property(x => x.ReferenciaId).HasColumnName("id_referencia");
        builder.Property(x => x.PedimentoNumber).HasColumnName("numero_pedimento").HasMaxLength(15).IsFixedLength();
        builder.Property(x => x.Patente).HasColumnName("patente").HasMaxLength(4).IsFixedLength();
        builder.Property(x => x.OperationTypeCode).HasColumnName("tipo_operacion");
        builder.Property(x => x.PedimentoKeyCode).HasColumnName("clave_pedimento").HasMaxLength(2).IsFixedLength();
        builder.Property(x => x.CustomsRegimeCode).HasColumnName("clave_regimen").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.GoodsDestinationCode).HasColumnName("clave_destino").HasMaxLength(2);
        builder.Property(x => x.ClearanceAduanaCode).HasColumnName("clave_aduana_despacho").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.EntryAduanaCode).HasColumnName("clave_aduana_entrada").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.EntryTransportModeCode).HasColumnName("medio_entrada").HasMaxLength(2);
        builder.Property(x => x.ArrivalTransportModeCode).HasColumnName("medio_arribo").HasMaxLength(2);
        builder.Property(x => x.ExitTransportModeCode).HasColumnName("medio_salida").HasMaxLength(2);
        builder.Property(x => x.ExchangeRate).HasColumnName("tipo_cambio").HasPrecision(10, 5);
        builder.Property(x => x.GrossWeight).HasColumnName("peso_bruto").HasPrecision(14, 3);
        builder.Property(x => x.ValueInUsd).HasColumnName("valor_dolares").HasPrecision(16, 2);
        builder.Property(x => x.CustomsValue).HasColumnName("valor_aduana").HasPrecision(16, 2);
        builder.Property(x => x.CommercialValue).HasColumnName("valor_comercial").HasPrecision(16, 2);
        builder.Property(x => x.Freight).HasColumnName("fletes").HasPrecision(16, 2);
        builder.Property(x => x.Insurance).HasColumnName("seguros").HasPrecision(16, 2);
        builder.Property(x => x.Packaging).HasColumnName("embalajes").HasPrecision(16, 2);
        builder.Property(x => x.OtherIncrementables).HasColumnName("otros_incrementables").HasPrecision(16, 2);
        builder.Property(x => x.EntryDate).HasColumnName("fecha_entrada");
        builder.Property(x => x.PaymentDate).HasColumnName("fecha_pago");
        builder.Property(x => x.TotalCash).HasColumnName("total_efectivo").HasPrecision(16, 2);
        builder.Property(x => x.TotalOther).HasColumnName("total_otros").HasPrecision(16, 2);
        builder.Property(x => x.Status).HasColumnName("estado").HasMaxLength(20);
        builder.Property(x => x.GlosadorId).HasColumnName("id_glosador");

        builder.HasIndex(x => x.ReferenciaId).IsUnique().HasDatabaseName("uq_ope_pedimento_1");
        builder.HasIndex(x => x.PedimentoNumber).IsUnique().HasDatabaseName("uq_ope_pedimento_2");

        builder.HasOne(x => x.Referencia)
            .WithOne(x => x.Pedimento)
            .HasForeignKey<PedimentoEntity>(x => x.ReferenciaId)
            .HasConstraintName("fk_ope_pedimento_id_referencia")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.CustomsBroker)
            .WithMany()
            .HasForeignKey(x => x.Patente)
            .HasConstraintName("fk_ope_pedimento_patente")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.OperationType)
            .WithMany()
            .HasForeignKey(x => x.OperationTypeCode)
            .HasConstraintName("fk_ope_pedimento_tipo_operacion")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PedimentoKey)
            .WithMany()
            .HasForeignKey(x => x.PedimentoKeyCode)
            .HasConstraintName("fk_ope_pedimento_clave_pedimento")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CustomsRegime)
            .WithMany()
            .HasForeignKey(x => x.CustomsRegimeCode)
            .HasConstraintName("fk_ope_pedimento_clave_regimen")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.GoodsDestination)
            .WithMany()
            .HasForeignKey(x => x.GoodsDestinationCode)
            .HasConstraintName("fk_ope_pedimento_clave_destino")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ClearanceAduana)
            .WithMany()
            .HasForeignKey(x => x.ClearanceAduanaCode)
            .HasConstraintName("fk_ope_pedimento_clave_aduana_despacho")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.EntryAduana)
            .WithMany()
            .HasForeignKey(x => x.EntryAduanaCode)
            .HasConstraintName("fk_ope_pedimento_clave_aduana_entrada")
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.EntryTransportMode)
            .WithMany()
            .HasForeignKey(x => x.EntryTransportModeCode)
            .HasConstraintName("fk_ope_pedimento_medio_entrada")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ArrivalTransportMode)
            .WithMany()
            .HasForeignKey(x => x.ArrivalTransportModeCode)
            .HasConstraintName("fk_ope_pedimento_medio_arribo")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ExitTransportMode)
            .WithMany()
            .HasForeignKey(x => x.ExitTransportModeCode)
            .HasConstraintName("fk_ope_pedimento_medio_salida")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Glosador)
            .WithMany()
            .HasForeignKey(x => x.GlosadorId)
            .HasConstraintName("fk_ope_pedimento_id_glosador")
            .OnDelete(DeleteBehavior.SetNull);
    }
}
