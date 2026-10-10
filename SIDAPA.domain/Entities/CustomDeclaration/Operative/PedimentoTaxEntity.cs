using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.domain.Entities.CustomDeclaration.Operative;

/// <summary>
/// Tabla <c>ope_contribucion_pedimento</c>: Contribuciones a nivel pedimento (DTA, PRV). (Origen: Anexo 22 (cuadro de liquidación))
/// </summary>
public class PedimentoTaxEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Pedimento.</summary>
    public int PedimentoId { get; set; }
    /// <summary>Contribución.</summary>
    public short TaxCode { get; set; }
    /// <summary>Tipo de tasa.</summary>
    public string RateTypeCode { get; set; } = null!;
    /// <summary>Tasa aplicada.</summary>
    public decimal Rate { get; set; }
    /// <summary>Forma de pago.</summary>
    public string PaymentMethodCode { get; set; } = null!;
    /// <summary>Importe.</summary>
    public decimal Amount { get; set; }

    public PedimentoEntity Pedimento { get; set; } = null!;
    public TaxEntity Tax { get; set; } = null!;
    public RateTypeEntity RateType { get; set; } = null!;
    public PaymentMethodEntity PaymentMethod { get; set; } = null!;
}
