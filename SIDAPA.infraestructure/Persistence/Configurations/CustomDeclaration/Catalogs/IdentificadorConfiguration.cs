using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.infraestructure.Persistence.Configurations.CustomDeclaration.Catalogs;

public class IdentificadorConfiguration : IEntityTypeConfiguration<IdentificadorEntity>
{
    public void Configure(EntityTypeBuilder<IdentificadorEntity> builder)
    {
        builder.ToTable("cat_identificador");
        builder.HasKey(x => x.Id).HasName("pk_cat_identificador");

        builder.Property(x => x.Id).HasColumnName("id_identificador").UseIdentityAlwaysColumn();
        builder.Property(x => x.Code).HasColumnName("clave").HasMaxLength(2).IsFixedLength();
        builder.Property(x => x.Level).HasColumnName("nivel").HasMaxLength(1).IsFixedLength();
        builder.Property(x => x.Description).HasColumnName("descripcion").HasMaxLength(200);
        builder.Property(x => x.ApplicationCases).HasColumnName("supuestos_aplicacion");
        builder.Property(x => x.Complement1).HasColumnName("complemento1");
        builder.Property(x => x.Complement2).HasColumnName("complemento2");
        builder.Property(x => x.Complement3).HasColumnName("complemento3");
        builder.Property(x => x.IsActive).HasColumnName("vigente");
        builder.Property(x => x.UpdatedOn).HasColumnName("fecha_actualizacion");

        builder.HasIndex(x => new { x.Code, x.Level }).IsUnique().HasDatabaseName("uq_cat_identificador_1");
    }
}
