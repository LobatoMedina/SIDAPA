using Microsoft.AspNetCore.Mvc;
using SIDAPA.application.Interface;

namespace SIDAPA.presentation.Controllers.Api;

[ApiController]
[Route("api/dev/taxscan")]
public class DevTaxScanController(ITaxScanClient taxScanClient) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Read(IFormFile file, CancellationToken ct)
    {
        await using var stream = file.OpenReadStream();
        var result = await taxScanClient.ReadInvoiceAsync(stream, file.FileName, ct);
        return Ok(result);
    }
}