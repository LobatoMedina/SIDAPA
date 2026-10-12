using SIDAPA.domain.Entities.Core.Catalogs;

namespace SIDAPA.domain.Entities.Core.Operative;

/// <summary>
/// Tabla <c>ope_solicitud_documento</c>: Solicitudes de documentos faltantes al cliente (HU-04, HU-05). (Origen: Sistema)
/// </summary>
public class DocumentRequestEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Referencia.</summary>
    public int ReferenciaId { get; set; }
    /// <summary>Documento solicitado.</summary>
    public short DocumentTypeId { get; set; }
    /// <summary>Explicación para el cliente.</summary>
    public string? Note { get; set; }
    /// <summary>Quién lo pidió.</summary>
    public int RequestedByUserId { get; set; }
    /// <summary>Cuándo se pidió.</summary>
    public DateTime RequestedAt { get; set; }
    /// <summary>Documento que subió el cliente.</summary>
    public int? ResponseDocumentId { get; set; }
    /// <summary>Cuándo lo subió.</summary>
    public DateTime? AttendedAt { get; set; }

    public ReferenciaEntity Referencia { get; set; } = null!;
    public DocumentTypeEntity DocumentType { get; set; } = null!;
    public UserEntity RequestedByUser { get; set; } = null!;
    public DocumentEntity? ResponseDocument { get; set; }
}
