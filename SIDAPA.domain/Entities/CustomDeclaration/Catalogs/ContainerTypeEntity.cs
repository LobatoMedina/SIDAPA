namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_tipo_contenedor</c>: Tipos de contenedores y vehículos de autotransporte. (Origen: Apéndice 10)
/// </summary>
public class ContainerTypeEntity
{
    /// <summary>Clave del tipo de contenedor.</summary>
    public string Code { get; set; } = null!;
    /// <summary>Tipo de contenedor o vehículo.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }
}
