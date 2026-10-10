namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_medio_transporte</c>: Medios de transporte de entrada, arribo y salida. (Origen: Apéndice 3)
/// </summary>
public class TransportModeEntity
{
    /// <summary>Clave del medio de transporte (1 = Marítimo).</summary>
    public string Code { get; set; } = null!;
    /// <summary>Nombre del medio de transporte.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }
}
