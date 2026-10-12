namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_regulacion</c>: Permisos y regulaciones no arancelarias (RRNA) por dependencia. (Origen: Apéndice 9)
/// </summary>
public class RegulationEntity
{
    /// <summary>Identificador interno.</summary>
    public int Id { get; set; }
    /// <summary>Dependencia que emite el permiso. Única junto con la clave.</summary>
    public short GovernmentAgencyId { get; set; }
    /// <summary>Clave del permiso (C1, S1, A1, etc.). Única junto con la dependencia.</summary>
    public string Code { get; set; } = null!;
    /// <summary>Descripción del permiso.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }

    public GovernmentAgencyEntity GovernmentAgency { get; set; } = null!;
}
