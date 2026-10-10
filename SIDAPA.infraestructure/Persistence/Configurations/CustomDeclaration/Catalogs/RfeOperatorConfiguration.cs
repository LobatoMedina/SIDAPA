using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class RfeOperatorConfiguration : IEntityTypeConfiguration<RfeOperatorEntity>
{
    public void Configure(EntityTypeBuilder<RfeOperatorEntity> builder)
    {
        builder.ToTable("cat_rfe_operador");
        builder.HasKey(x => x.Code).HasName("pk_cat_rfe_operador");

        builder.Property(x => x.Code).HasColumnName("clave_operador").HasMaxLength(4).IsFixedLength();
        builder.Property(x => x.RfeCode).HasColumnName("clave_rfe").HasMaxLength(3).IsFixedLength();
        builder.Property(x => x.Name).HasColumnName("nombre").HasMaxLength(200);
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");

        builder.HasOne(x => x.Rfe)
            .WithMany(x => x.Operators)
            .HasForeignKey(x => x.RfeCode)
            .HasConstraintName("fk_cat_rfe_operador_clave_rfe")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
