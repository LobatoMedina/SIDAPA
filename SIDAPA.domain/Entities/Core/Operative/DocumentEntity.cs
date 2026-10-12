using SIDAPA.domain.Entities.Core.Catalogs;

namespace SIDAPA.domain.Entities.Core.Operative;

/// <summary>
/// Tabla <c>ope_documento</c>: Archivos del expediente guardados en Cloud Storage. (Origen: Sistema)
/// </summary>
public class DocumentEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Referencia.</summary>
    public int ReferenciaId { get; set; }
    /// <summary>Tipo de documento.</summary>
    public short DocumentTypeId { get; set; }
    /// <summary>Nombre original.</summary>
    public string FileName { get; set; } = null!;
    /// <summary>Ruta en el bucket.</summary>
    public string BucketPath { get; set; } = null!;
    /// <summary>Tamaño (máximo 20 MB).</summary>
    public int SizeInBytes { get; set; }
    /// <summary>Recibido, Correcto, Faltante o Error.</summary>
    public string Status { get; set; } = null!;
    /// <summary>Observación del Capturador.</summary>
    public string? Note { get; set; }
    /// <summary>Quién lo subió.</summary>
    public int UploadedByUserId { get; set; }
    /// <summary>Fecha de carga.</summary>
    public DateTime UploadedAt { get; set; }

    public ReferenciaEntity Referencia { get; set; } = null!;
    public DocumentTypeEntity DocumentType { get; set; } = null!;
    public UserEntity UploadedByUser { get; set; } = null!;
}
