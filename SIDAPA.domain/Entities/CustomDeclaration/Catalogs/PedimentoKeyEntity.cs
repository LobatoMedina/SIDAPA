namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_clave_pedimento</c>: Claves de pedimento con sus supuestos de aplicación. (Origen: Apéndice 2)
/// </summary>
public class PedimentoKeyEntity
{
    /// <summary>Clave de pedimento (A1, IN, V1, etc.).</summary>
    public string Code { get; set; } = null!;
    /// <summary>Nombre de la clave.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Grupo del apéndice: Régimen definitivo, Temporales, Depósito fiscal, Tránsitos, RFE, Operaciones virtuales u Otros.</summary>
    public string Group { get; set; } = null!;
    /// <summary>Subgrupo cuando aplica: IMMEX, AGD, Industria automotriz, Transformación en recinto fiscalizado.</summary>
    public string? Subgroup { get; set; }
    /// <summary>Supuestos en los que se usa la clave (texto completo del apéndice).</summary>
    public string ApplicationCases { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }
}
