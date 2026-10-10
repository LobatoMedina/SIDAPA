namespace SIDAPA.domain.Entities.Core.Catalogs;

/// <summary>
/// Tabla <c>cat_tipo_documento</c>: Documentos que puede mandar el cliente (factura, B/L, lista de empaque, certificado de origen...). (Origen: Sistema)
/// </summary>
public class DocumentTypeEntity
{
    /// <summary>Identificador.</summary>
    public short Id { get; set; }
    /// <summary>Nombre del documento.</summary>
    public string Name { get; set; } = null!;
}
