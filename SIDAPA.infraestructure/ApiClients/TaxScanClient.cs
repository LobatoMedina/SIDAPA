using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using SIDAPA.application.DTOs.TaxScan;
using SIDAPA.application.Interface;

namespace SIDAPA.infraestructure.ApiClients;

/// <summary>
/// Llama por HTTP al lector en Python (FastAPI). Contrato: POST /invoices/read
/// </summary>
public class TaxScanClient(HttpClient httpClient) : ITaxScanClient
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    public async Task<InvoiceReadResultDto> ReadInvoiceAsync(Stream file, string fileName, CancellationToken ct)
    {
        using var content = new MultipartFormDataContent();

        var fileContent = new StreamContent(file);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue(GetContentType(fileName));

        content.Add(fileContent, "file", fileName);

        using var response = await httpClient.PostAsync("invoices/read", content, ct);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(ct);
            throw new InvalidOperationException(
                $"The reader returned {(int)response.StatusCode} for '{fileName}': {body}");
        }

        return await response.Content.ReadFromJsonAsync<InvoiceReadResultDto>(JsonOptions, ct)
               ?? throw new InvalidOperationException($"The reader returned an empty response for '{fileName}'.");
    }

    private static string GetContentType(string fileName) =>
        Path.GetExtension(fileName).ToLowerInvariant() switch
        {
            ".pdf"  => "application/pdf",
            ".xml"  => "application/xml",
            ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            ".xls"  => "application/vnd.ms-excel",
            _       => "application/octet-stream"
        };
}