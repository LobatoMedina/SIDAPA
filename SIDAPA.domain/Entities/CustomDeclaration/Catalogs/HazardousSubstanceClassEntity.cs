namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_clase_sustancia_peligrosa</c>: Clases de sustancias peligrosas. (Origen: Apéndice 19)
/// </summary>
public class HazardousSubstanceClassEntity
{
    /// <summary>Clase de la 1 a la 9.</summary>
    public string Code { get; set; } = null!;
    /// <summary>Explosivos, gases, líquidos inflamables, etc.</summary>
    public string Name { get; set; } = null!;
    /// <summary>Definición de la clase (documento Apendice 19.docx de Reglas de Negocio).</summary>
    public string? Definition { get; set; }
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }

    public ICollection<HazardousSubstanceDivisionEntity> Divisions { get; set; } = [];
}
