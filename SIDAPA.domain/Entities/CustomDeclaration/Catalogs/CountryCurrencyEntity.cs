namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_moneda_pais</c>: Relación de cada país con la moneda que usa (un país puede tener dos, como China). (Origen: Apéndice 5)
/// </summary>
public class CountryCurrencyEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Nombre del país como aparece en el apéndice.</summary>
    public string CountryName { get; set; } = null!;
    /// <summary>Moneda que usa el país.</summary>
    public string CurrencyCode { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }

    public CurrencyEntity Currency { get; set; } = null!;
}
