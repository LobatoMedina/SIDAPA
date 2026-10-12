namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_incoterm</c>: Términos de facturación (Incoterms). (Origen: Apéndice 14)
/// </summary>
public class IncotermEntity
{
    /// <summary>Incoterm (FOB, CIF, EXW, etc.).</summary>
    public string Code { get; set; } = null!;
    /// <summary>Nombre del término.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Grupo C, D, E o F.</summary>
    public string Group { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }
}
