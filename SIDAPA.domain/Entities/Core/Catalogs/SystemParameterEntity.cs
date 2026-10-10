namespace SIDAPA.domain.Entities.Core.Catalogs;

/// <summary>
/// Tabla <c>cat_parametro</c>: Valores que cambian por ley y no deben ir fijos en el código: tasa de IVA, tasa y cuota mínima de DTA, cuota de prevalidación, tamaño máximo de archivo, etc. (Origen: Configuración)
/// </summary>
public class SystemParameterEntity
{
    /// <summary>Nombre del parámetro (IVA_TASA, DTA_TASA, DTA_CUOTA_MINIMA, PRV_CUOTA...).</summary>
    public string Key { get; set; } = null!;
    /// <summary>Valor del parámetro.</summary>
    public string Value { get; set; } = null!;
    /// <summary>Fecha desde la que aplica.</summary>
    public DateOnly ValidFrom { get; set; }
    /// <summary>Para qué sirve y de dónde sale (ley o regla).</summary>
    public string Description { get; set; } = null!;
}
