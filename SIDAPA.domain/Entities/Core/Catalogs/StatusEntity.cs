namespace SIDAPA.domain.Entities.Core.Catalogs;

/// <summary>
/// Tabla <c>cat_estatus</c>: Los 15 estatus de una referencia (de Recibida a Cerrado). (Origen: Sistema)
/// </summary>
public class StatusEntity
{
    /// <summary>Identificador.</summary>
    public short Id { get; set; }
    /// <summary>Nombre del estatus.</summary>
    public string Name { get; set; } = null!;
    /// <summary>Orden en el flujo.</summary>
    public short SortOrder { get; set; }
}
