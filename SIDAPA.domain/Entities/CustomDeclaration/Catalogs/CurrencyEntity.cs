namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_moneda</c>: Monedas que se pueden declarar en la factura. (Origen: Apéndice 5)
/// </summary>
public class CurrencyEntity
{
    /// <summary>Clave ISO de la moneda (USD, EUR, CNY).</summary>
    public string Code { get; set; } = null!;
    /// <summary>Nombre de la moneda.</summary>
    public string Name { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }
}
