namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_regimen</c>: Regímenes aduaneros. (Origen: Apéndice 16)
/// </summary>
public class CustomsRegimeEntity
{
    /// <summary>Clave del régimen (IMD, EXD, ITE, etc.).</summary>
    public string Code { get; set; } = null!;
    /// <summary>Nombre del régimen.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }
}
