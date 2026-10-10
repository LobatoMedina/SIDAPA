namespace SIDAPA.application.DTOs.TaxScan;

public record SupplierDto(
    string? Name,
    string? TaxId,
    string? Address,
    string? Country
);