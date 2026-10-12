using SIDAPA.domain.Entities.Core.Operative;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.domain.Entities.CustomDeclaration.Operative;

/// <summary>
/// Tabla <c>ope_factura</c>: Factura comercial leída. (Origen: Sistema)
/// </summary>
public class InvoiceEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Referencia.</summary>
    public int ReferenciaId { get; set; }
    /// <summary>Archivo del que se leyó.</summary>
    public int? DocumentId { get; set; }
    /// <summary>Proveedor.</summary>
    public int SupplierId { get; set; }
    /// <summary>Número de factura (o CFDI/acuse de valor COVE).</summary>
    public string InvoiceNumber { get; set; } = null!;
    /// <summary>Fecha.</summary>
    public DateOnly InvoiceDate { get; set; }
    /// <summary>Moneda.</summary>
    public string CurrencyCode { get; set; } = null!;
    /// <summary>Término de facturación.</summary>
    public string IncotermCode { get; set; } = null!;
    /// <summary>Valor total en la moneda de la factura.</summary>
    public decimal ValueInCurrency { get; set; }
    /// <summary>Factor de equivalencia a dólares.</summary>
    public decimal? CurrencyFactor { get; set; }
    /// <summary>Valor en dólares.</summary>
    public decimal? ValueInUsd { get; set; }
    /// <summary>XML, OCR o Layout.</summary>
    public string ReadSource { get; set; } = null!;
    /// <summary>Revisada por el Capturador.</summary>
    public bool IsConfirmed { get; set; }

    public ReferenciaEntity Referencia { get; set; } = null!;
    public DocumentEntity? Document { get; set; }
    public SupplierEntity Supplier { get; set; } = null!;
    public CurrencyEntity Currency { get; set; } = null!;
    public IncotermEntity Incoterm { get; set; } = null!;

    public ICollection<InvoiceLineEntity> Lines { get; set; } = [];
}
