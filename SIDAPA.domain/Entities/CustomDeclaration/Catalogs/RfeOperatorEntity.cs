namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_rfe_operador</c>: Operadores autorizados dentro de cada RFE. (Origen: Apéndice 21)
/// </summary>
public class RfeOperatorEntity
{
    /// <summary>Clave del operador.</summary>
    public string Code { get; set; } = null!;
    /// <summary>RFE donde opera.</summary>
    public string RfeCode { get; set; } = null!;
    /// <summary>Razón social del operador.</summary>
    public string Name { get; set; } = null!;
    /// <summary>Indica si la clave sigue vigente en el Anexo 22 (las claves no se borran, se dan de baja).</summary>
    public bool IsActive { get; set; }
    /// <summary>Fecha de la publicación del Anexo 22 de la que se tomó el registro.</summary>
    public DateOnly? UpdatedOn { get; set; }

    public RfeEntity Rfe { get; set; } = null!;
}
