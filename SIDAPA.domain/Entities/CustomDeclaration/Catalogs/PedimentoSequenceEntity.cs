namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_consecutivo_pedimento</c>: Último número consecutivo usado por patente, aduana y año (para armar el número de 15 dígitos). (Origen: Configuración)
/// </summary>
public class PedimentoSequenceEntity
{
    /// <summary>Identificador interno.</summary>
    public int Id { get; set; }
    /// <summary>Patente. Única junto con la aduana y el año.</summary>
    public string Patente { get; set; } = null!;
    /// <summary>Aduana. Única junto con la patente y el año.</summary>
    public string AduanaCode { get; set; } = null!;
    /// <summary>Año. Único junto con la patente y la aduana.</summary>
    public short Year { get; set; }
    /// <summary>Último consecutivo asignado (7 dígitos, el primero es el último dígito del año).</summary>
    public int LastSequence { get; set; }

    public CustomsBrokerEntity CustomsBroker { get; set; } = null!;
    public AduanaEntity Aduana { get; set; } = null!;
}
