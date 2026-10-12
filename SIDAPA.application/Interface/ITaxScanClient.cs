using SIDAPA.application.DTOs.TaxScan;
using SIDAPA.application.Interface;

public interface ITaxScanClient
{
    Task<InvoiceReadResultDto> ReadInvoiceAsync(Stream file, string fileName, CancellationToken ct);
}