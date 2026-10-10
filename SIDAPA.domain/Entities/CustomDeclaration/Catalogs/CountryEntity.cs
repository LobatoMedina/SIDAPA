namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_pais</c>: Países con su clave FIII y M3 del SAAI. (Origen: Apéndice 4)
/// </summary>
public class CountryEntity
{
    /// <summary>Clave M3 de tres letras que se declara en el pedimento (MEX, USA, FRA).</summary>
    public string Code { get; set; } = null!;
    /// <summary>Clave FIII de dos caracteres del SAAI.</summary>
    public string FiiiCode { get; set; } = null!;
    /// <summary>Nombre oficial del país.</summary>
    public string Name { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }
}
