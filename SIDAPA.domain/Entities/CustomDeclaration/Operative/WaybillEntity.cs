namespace SIDAPA.domain.Entities.CustomDeclaration.Operative;

/// <summary>
/// Tabla <c>ope_guia</c>: Guías o conocimientos de embarque master y house (HU-13). (Origen: Anexo 22 (guías))
/// </summary>
public class WaybillEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Pedimento.</summary>
    public int PedimentoId { get; set; }
    /// <summary>Número de guía o B/L.</summary>
    public string Number { get; set; } = null!;
    /// <summary>M = master, H = house.</summary>
    public string Type { get; set; } = null!;

    public PedimentoEntity Pedimento { get; set; } = null!;
}
