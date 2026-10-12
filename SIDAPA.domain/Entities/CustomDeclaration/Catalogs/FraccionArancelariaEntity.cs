namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_fraccion_arancelaria</c>: Fracciones arancelarias con NICO, unidad de tarifa y tasas. Se necesita para sugerir y validar fracciones (HU-09, HU-10) y calcular el IGI (HU-16). (Origen: TIGIE (LIGIE) y NICO)
/// </summary>
public class FraccionArancelariaEntity
{
    /// <summary>Identificador interno.</summary>
    public int Id { get; set; }
    /// <summary>Fracción arancelaria de 8 dígitos. Única junto con el NICO.</summary>
    public string Fraccion { get; set; } = null!;
    /// <summary>Número de identificación comercial. Único junto con la fracción.</summary>
    public string Nico { get; set; } = null!;
    /// <summary>Descripción de la mercancía según la tarifa.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Unidad de medida de la tarifa (UMT).</summary>
    public string TariffUnitCode { get; set; } = null!;
    /// <summary>Arancel de importación (porcentaje).</summary>
    public decimal? ImportDutyRate { get; set; }
    /// <summary>Arancel de exportación (porcentaje).</summary>
    public decimal? ExportDutyRate { get; set; }
    /// <summary>Fecha desde la que aplica.</summary>
    public DateOnly ValidFrom { get; set; }
    /// <summary>Fecha en que dejó de aplicar.</summary>
    public DateOnly? ValidTo { get; set; }

    public UnitOfMeasureEntity TariffUnit { get; set; } = null!;
}
