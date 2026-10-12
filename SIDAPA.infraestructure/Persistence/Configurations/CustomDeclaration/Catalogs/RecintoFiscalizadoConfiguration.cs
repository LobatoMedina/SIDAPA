using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class RecintoFiscalizadoConfiguration : IEntityTypeConfiguration<RecintoFiscalizadoEntity>
{
    public void Configure(EntityTypeBuilder<RecintoFiscalizadoEntity> builder)
    {
        builder.ToTable("cat_recinto_fiscalizado");
        builder.HasKey(x => x.Code).HasName("pk_cat_recinto_fiscalizado");

        builder.Property(x => x.Code).HasColumnName("clave").ValueGeneratedNever();
        builder.Property(x => x.AduanaName).HasColumnName("aduana").HasMaxLength(80);
        builder.Property(x => x.Name).HasColumnName("nombre").HasMaxLength(200);
        builder.Property(x => x.IsEtrAuthorized).HasColumnName("autorizado_etr");
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");
    }
}
