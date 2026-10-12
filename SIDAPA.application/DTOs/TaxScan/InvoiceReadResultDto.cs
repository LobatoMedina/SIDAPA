namespace SIDAPA.application.DTOs.TaxScan;

/// <summary>
/// Respuesta del lector (sidapa-reader) al leer una factura. Contrato v1: POST /invoices/read
/// </summary>
public record InvoiceReadResultDto(
    string ReadSource,              // "XML", "OCR" o "Layout"
    string? InvoiceNumber,
    DateOnly? InvoiceDate,
    string? Currency,               // clave ISO, debe existir en cat_moneda
    string? Incoterm,               // debe existir en cat_incoterm
    SupplierDto? Supplier,
    decimal? Total,
    IReadOnlyList<InvoiceLineDto> Lines,
    IReadOnlyList<string> Warnings  // avisos del lector: "no se encontró el incoterm", etc.
);