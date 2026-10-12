using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.domain.Entities.CustomDeclaration.Operative;

/// <summary>
/// Tabla <c>ope_transporte_pedimento</c>: Identificación del transporte (buque, país, transportista). (Origen: Anexo 22 (transporte))
/// </summary>
public class PedimentoTransportEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Pedimento.</summary>
    public int PedimentoId { get; set; }
    /// <summary>Nombre del buque o identificación del transporte.</summary>
    public string Identification { get; set; } = null!;
    /// <summary>País del medio de transporte.</summary>
    public string CountryCode { get; set; } = null!;
    /// <summary>Nombre del transportista.</summary>
    public string? Carrier { get; set; }

    public PedimentoEntity Pedimento { get; set; } = null!;
    public CountryEntity Country { get; set; } = null!;
}
