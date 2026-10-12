namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_identificador</c>: Identificadores a nivel pedimento (G) o partida (P) y lo que se declara en cada complemento. (Origen: Apéndice 8)
/// </summary>
public class IdentificadorEntity
{
    /// <summary>Identificador interno.</summary>
    public int Id { get; set; }
    /// <summary>Clave del identificador (EC, CR, TL, etc.). Única junto con el nivel.</summary>
    public string Code { get; set; } = null!;
    /// <summary>G = pedimento, P = partida. Único junto con la clave.</summary>
    public string Level { get; set; } = null!;
    /// <summary>Nombre del identificador.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Cuándo se debe declarar.</summary>
    public string ApplicationCases { get; set; } = null!;
    /// <summary>Qué se declara en el complemento 1.</summary>
    public string? Complement1 { get; set; }
    /// <summary>Qué se declara en el complemento 2.</summary>
    public string? Complement2 { get; set; }
    /// <summary>Qué se declara en el complemento 3.</summary>
    public string? Complement3 { get; set; }
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }
}
