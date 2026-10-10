namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_aduana_seccion</c>: Aduanas y secciones aduaneras donde se despacha la mercancía. (Origen: Apéndice 1)
/// </summary>
public class AduanaEntity
{
    /// <summary>Clave aduana-sección de 3 dígitos (por ejemplo 430 = Veracruz).</summary>
    public string Code { get; set; } = null!;
    /// <summary>Dos dígitos de la aduana.</summary>
    public string AduanaCode { get; set; } = null!;
    /// <summary>Dígito de la sección aduanera.</summary>
    public string Section { get; set; } = null!;
    /// <summary>Nombre de la aduana o sección, municipio y estado.</summary>
    public string Name { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }
}
