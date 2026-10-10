namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_forma_pago</c>: Formas de pago de las contribuciones. (Origen: Apéndice 13)
/// </summary>
public class PaymentMethodEntity
{
    /// <summary>Clave de forma de pago (0 = Efectivo).</summary>
    public string Code { get; set; } = null!;
    /// <summary>Forma de pago.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }
}
