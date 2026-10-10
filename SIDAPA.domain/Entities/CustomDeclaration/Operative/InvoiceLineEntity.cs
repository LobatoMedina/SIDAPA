using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.domain.Entities.CustomDeclaration.Operative;

/// <summary>
/// Tabla <c>ope_renglon_factura</c>: Productos de cada factura. (Origen: Sistema)
/// </summary>
public class InvoiceLineEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Factura.</summary>
    public int InvoiceId { get; set; }
    /// <summary>Número de parte.</summary>
    public string PartNumber { get; set; } = null!;
    /// <summary>Descripción en la factura.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Cantidad comercial.</summary>
    public decimal Quantity { get; set; }
    /// <summary>Unidad comercial.</summary>
    public string UnitCode { get; set; } = null!;
    /// <summary>Precio unitario.</summary>
    public decimal UnitPrice { get; set; }
    /// <summary>Importe.</summary>
    public decimal Amount { get; set; }
    /// <summary>País de origen.</summary>
    public string OriginCountryCode { get; set; } = null!;
    /// <summary>Porcentaje de seguridad de la lectura.</summary>
    public decimal? Confidence { get; set; }
    /// <summary>Producto del catálogo de partes.</summary>
    public int? ProductId { get; set; }

    public InvoiceEntity Invoice { get; set; } = null!;
    public UnitOfMeasureEntity Unit { get; set; } = null!;
    public CountryEntity OriginCountry { get; set; } = null!;
    public ProductEntity? Product { get; set; }
}
