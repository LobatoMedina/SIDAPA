namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_destino_mercancia</c>: Destinos u orígenes de la mercancía (franja, región, interior). (Origen: Apéndice 15)
/// </summary>
public class GoodsDestinationEntity
{
    /// <summary>Clave del destino (9 = Interior del país).</summary>
    public string Code { get; set; } = null!;
    /// <summary>Destino.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }
}
