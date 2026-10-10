using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.domain.Entities.Core.Catalogs;

/// <summary>
/// Tabla <c>cat_documento_requerido</c>: Qué documentos son obligatorios según el tipo de operación y la clave de pedimento (HU-03). (Origen: Proceso UPS (notas 1 y 2))
/// </summary>
public class RequiredDocumentEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Importación o exportación.</summary>
    public short OperationTypeCode { get; set; }
    /// <summary>Clave de pedimento; vacío = aplica a todas.</summary>
    public string? PedimentoKeyCode { get; set; }
    /// <summary>Documento requerido.</summary>
    public short DocumentTypeId { get; set; }
    /// <summary>Obligatorio u opcional.</summary>
    public bool IsMandatory { get; set; }

    public OperationTypeEntity OperationType { get; set; } = null!;
    public PedimentoKeyEntity? PedimentoKey { get; set; }
    public DocumentTypeEntity DocumentType { get; set; } = null!;
}
