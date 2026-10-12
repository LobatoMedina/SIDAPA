using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIDAPA.domain.Entities.Core.Catalogs;
using SIDAPA.domain.Enums.Core;

namespace SIDAPA.infraestructure.Persistence.Configurations.Core.Catalogs;

public class StatusConfiguration : IEntityTypeConfiguration<StatusEntity>
{
    public void Configure(EntityTypeBuilder<StatusEntity> builder)
    {
        builder.ToTable("cat_estatus");
        builder.HasKey(x => x.Id).HasName("pk_cat_estatus");

        builder.Property(x => x.Id).HasColumnName("id_estatus").ValueGeneratedNever();
        builder.Property(x => x.Name).HasColumnName("nombre").HasMaxLength(40);
        builder.Property(x => x.SortOrder).HasColumnName("orden");

        builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName("uq_cat_estatus_1");

        builder.HasData(
            Status(ReferenciaStatusEnum.RECIBIDA, "Recibida"),
            Status(ReferenciaStatusEnum.EN_REVISION, "En revisión"),
            Status(ReferenciaStatusEnum.EN_ESPERA_DE_DOCUMENTOS, "En espera de documentos"),
            Status(ReferenciaStatusEnum.EXPEDIENTE_COMPLETO, "Expediente completo"),
            Status(ReferenciaStatusEnum.FACTURA_LEIDA, "Factura leída"),
            Status(ReferenciaStatusEnum.FACTURA_CONFIRMADA, "Factura confirmada"),
            Status(ReferenciaStatusEnum.EN_CLASIFICACION, "En clasificación"),
            Status(ReferenciaStatusEnum.BORRADOR_DE_PEDIMENTO, "Borrador de pedimento"),
            Status(ReferenciaStatusEnum.EN_GLOSA, "En glosa"),
            Status(ReferenciaStatusEnum.CON_ANOTACIONES, "Con anotaciones"),
            Status(ReferenciaStatusEnum.GLOSADO, "Glosado (Vo.Bo.)"),
            Status(ReferenciaStatusEnum.ARCHIVO_GENERADO, "Archivo generado"),
            Status(ReferenciaStatusEnum.RECHAZADO_POR_VALIDADOR, "Rechazado por validador"),
            Status(ReferenciaStatusEnum.VALIDADO, "Validado"),
            Status(ReferenciaStatusEnum.CERRADO, "Cerrado"));
    }

    private static StatusEntity Status(ReferenciaStatusEnum status, string name) =>
        new() { Id = (short)status, Name = name, SortOrder = (short)status };
}