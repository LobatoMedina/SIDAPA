namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_contribucion</c>: Contribuciones, cuotas compensatorias, gravámenes y derechos. (Origen: Apéndice 12)
/// </summary>
public class TaxEntity
{
    /// <summary>Clave de la contribución (1 = DTA, 3 = IVA, 6 = IGI/IGE).</summary>
    public short Code { get; set; }
    /// <summary>Nombre de la contribución.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Abreviatura (DTA, IVA, IGI/IGE, PRV).</summary>
    public string Abbreviation { get; set; } = null!;
    /// <summary>G = pedimento, P = partida, G/C = ambos.</summary>
    public string Level { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }
}
