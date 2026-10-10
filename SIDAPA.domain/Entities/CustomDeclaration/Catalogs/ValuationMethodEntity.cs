namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_metodo_valoracion</c>: Métodos de valoración de la mercancía. (Origen: Apéndice 11)
/// </summary>
public class ValuationMethodEntity
{
    /// <summary>Clave del método (1 = valor de transacción).</summary>
    public string Code { get; set; } = null!;
    /// <summary>Nombre del método.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }
}
