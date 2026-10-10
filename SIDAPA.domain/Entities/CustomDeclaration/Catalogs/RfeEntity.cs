namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_rfe</c>: Recintos fiscalizados estratégicos y su administrador. (Origen: Apéndice 21)
/// </summary>
public class RfeEntity
{
    /// <summary>Clave del recinto fiscalizado estratégico.</summary>
    public string Code { get; set; } = null!;
    /// <summary>Aduana que lo controla.</summary>
    public string AduanaName { get; set; } = null!;
    /// <summary>Razón social del administrador del RFE.</summary>
    public string Administrator { get; set; } = null!;
    /// <summary>Si colinda con la aduana.</summary>
    public bool IsAdjacent { get; set; }
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }

    public ICollection<RfeOperatorEntity> Operators { get; set; } = [];
}
