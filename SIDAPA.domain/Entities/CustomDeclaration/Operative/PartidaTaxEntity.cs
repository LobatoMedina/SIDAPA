using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.domain.Entities.CustomDeclaration.Operative;

/// <summary>
/// Tabla <c>ope_contribucion_partida</c>: Contribuciones por partida (IGI, IVA, IEPS, cuotas). (Origen: Anexo 22 (partidas))
/// </summary>
public class PartidaTaxEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Partida.</summary>
    public int PartidaId { get; set; }
    /// <summary>Contribución.</summary>
    public short TaxCode { get; set; }
    /// <summary>Tipo de tasa.</summary>
    public string RateTypeCode { get; set; } = null!;
    /// <summary>Tasa.</summary>
    public decimal Rate { get; set; }
    /// <summary>Forma de pago.</summary>
    public string PaymentMethodCode { get; set; } = null!;
    /// <summary>Importe.</summary>
    public decimal Amount { get; set; }

    public PartidaEntity Partida { get; set; } = null!;
    public TaxEntity Tax { get; set; } = null!;
    public RateTypeEntity RateType { get; set; } = null!;
    public PaymentMethodEntity PaymentMethod { get; set; } = null!;
}
