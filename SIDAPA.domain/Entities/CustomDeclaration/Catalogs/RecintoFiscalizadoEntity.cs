namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_recinto_fiscalizado</c>: Recintos fiscalizados por aduana. (Origen: Apéndice 6)
/// </summary>
public class RecintoFiscalizadoEntity
{
    /// <summary>Clave del recinto fiscalizado.</summary>
    public short Code { get; set; }
    /// <summary>Aduana a la que pertenece el recinto.</summary>
    public string AduanaName { get; set; } = null!;
    /// <summary>Razón social del recinto.</summary>
    public string Name { get; set; } = null!;
    /// <summary>Autorizado para elaboración, transformación o reparación.</summary>
    public bool IsEtrAuthorized { get; set; }
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }
}
