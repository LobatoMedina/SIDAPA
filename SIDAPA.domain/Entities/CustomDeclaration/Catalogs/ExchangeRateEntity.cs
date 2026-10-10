namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_tipo_cambio</c>: Tipo de cambio publicado por día; se usa para convertir el valor de las facturas (HU-15). (Origen: DOF / Banxico)
/// </summary>
public class ExchangeRateEntity
{
    /// <summary>Identificador interno.</summary>
    public int Id { get; set; }
    /// <summary>Fecha de publicación. Única junto con la moneda.</summary>
    public DateOnly Date { get; set; }
    /// <summary>Moneda (USD; para otras monedas se usa la equivalencia). Única junto con la fecha.</summary>
    public string CurrencyCode { get; set; } = null!;
    /// <summary>Pesos por unidad de moneda extranjera.</summary>
    public decimal Rate { get; set; }
    /// <summary>Equivalencia de la moneda en dólares (Banxico), para monedas distintas al dólar.</summary>
    public decimal? EquivalenceFactor { get; set; }
    /// <summary>DOF o Banxico.</summary>
    public string Source { get; set; } = null!;

    public CurrencyEntity Currency { get; set; } = null!;
}
