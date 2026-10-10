namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_division_sustancia_peligrosa</c>: Divisiones de cada clase de sustancia peligrosa. (Origen: Apéndice 19)
/// </summary>
public class HazardousSubstanceDivisionEntity
{
    /// <summary>División (1.1, 2.3, 5.2, etc.).</summary>
    public string Code { get; set; } = null!;
    /// <summary>Clase a la que pertenece.</summary>
    public string ClassCode { get; set; } = null!;
    /// <summary>Descripción de las sustancias de la división.</summary>
    public string Description { get; set; } = null!;

    public HazardousSubstanceClassEntity SubstanceClass { get; set; } = null!;
}
