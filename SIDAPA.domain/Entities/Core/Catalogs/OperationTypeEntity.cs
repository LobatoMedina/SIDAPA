namespace SIDAPA.domain.Entities.Core.Catalogs;

/// <summary>
/// Tabla <c>cat_tipo_operacion</c>: Tipo de operación del pedimento. (Origen: Anexo 22 (campo T. OPER))
/// </summary>
public class OperationTypeEntity
{
    /// <summary>1 = Importación, 2 = Exportación.</summary>
    public short Code { get; set; }
    /// <summary>Nombre.</summary>
    public string Description { get; set; } = null!;
}
