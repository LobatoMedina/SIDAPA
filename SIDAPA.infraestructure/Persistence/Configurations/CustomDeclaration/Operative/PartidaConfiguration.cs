using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Operative;

public class PartidaConfiguration : IEntityTypeConfiguration<PartidaEntity>
{
    public void Configure(EntityTypeBuilder<PartidaEntity> builder)
    {
        builder.ToTable("ope_partida");
        builder.HasKey(x => x.Id).HasName("pk_ope_partida");

        builder.Property(x => x.Id).HasColumnName("id_partida").UseIdentityAlwaysColumn();
        builder.Property(x => x.PedimentoId).HasColumnName("id_pedimento");
        builder.Property(x => x.PartidaNumber).HasColumnName("numero_partida");
        builder.Property(x => x.FraccionArancelariaId).HasColumnName("id_fraccion");
        builder.Property(x => x.Description).HasColumnName("descripcion").HasMaxLength(250);
        builder.Property(x => x.ValuationMethodCode).HasColumnName("clave_metodo_valoracion").HasMaxLength(1).IsFixedLength();
        builder.Property(x => x.CommercialUnitCode).HasColumnName("clave_umc").HasMaxLength(2);
        builder.Property(x => x.CommercialQuantity).HasColumnName("cantidad_umc").HasPrecision(14, 3);
        builder.Property(x => x.TariffUnitCode).HasColumnName("clave_umt").HasMaxLength(2);
        builder.Property(x => x.TariffQuantity).HasColumnName("cantidad_umt").HasPrecision(14, 3);
        builder.Property(x => x.OriginCountryCode).HasColumnName("clave_pais_origen").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.SellerCountryCode).HasColumnName("clave_pais_vendedor").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.CustomsValue).HasColumnName("valor_aduana").HasPrecision(16, 2);
        builder.Property(x => x.PricePaid).HasColumnName("precio_pagado").HasPrecision(16, 2);
        builder.Property(x => x.UnitPrice).HasColumnName("precio_unitario").HasPrecision(16, 5);
        builder.Property(x => x.AddedValue).HasColumnName("valor_agregado").HasPrecision(16, 2);

        builder.HasOne(x => x.Pedimento)
            .WithMany(x => x.Partidas)
            .HasForeignKey(x => x.PedimentoId)
            .HasConstraintName("fk_ope_partida_id_pedimento")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.FraccionArancelaria)
            .WithMany()
            .HasForeignKey(x => x.FraccionArancelariaId)
            .HasConstraintName("fk_ope_partida_id_fraccion")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ValuationMethod)
            .WithMany()
            .HasForeignKey(x => x.ValuationMethodCode)
            .HasConstraintName("fk_ope_partida_clave_metodo_valoracion")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CommercialUnit)
            .WithMany()
            .HasForeignKey(x => x.CommercialUnitCode)
            .HasConstraintName("fk_ope_partida_clave_umc")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TariffUnit)
            .WithMany()
            .HasForeignKey(x => x.TariffUnitCode)
            .HasConstraintName("fk_ope_partida_clave_umt")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.OriginCountry)
            .WithMany()
            .HasForeignKey(x => x.OriginCountryCode)
            .HasConstraintName("fk_ope_partida_clave_pais_origen")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SellerCountry)
            .WithMany()
            .HasForeignKey(x => x.SellerCountryCode)
            .HasConstraintName("fk_ope_partida_clave_pais_vendedor")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
