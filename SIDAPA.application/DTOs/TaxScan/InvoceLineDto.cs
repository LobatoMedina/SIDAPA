namespace SIDAPA.application.DTOs.TaxScan;

public record InvoiceLineDto(
    string? PartNumber,
    string? Description,
    decimal? Quantity,
    string? Unit,
    decimal? UnitPrice,
    decimal? Amount,
    string? OriginCountry,
    decimal? Confidence
);