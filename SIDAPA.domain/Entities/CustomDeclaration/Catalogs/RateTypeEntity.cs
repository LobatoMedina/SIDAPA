namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_tipo_tasa</c>: Tipos de tasa de las contribuciones. (Origen: Apéndice 18)
/// </summary>
public class RateTypeEntity
{
    /// <summary>Clave del tipo de tasa (1 = Porcentual).</summary>
    public string Code { get; set; } = null!;
    /// <summary>Tipo de tasa.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }
}
