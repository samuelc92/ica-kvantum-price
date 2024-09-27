using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace IcaKvantumPrice.ApiService.Shoppings.UploadReceipt;

[HttpPost("receipts"), AllowAnonymous]
public class UploadReceiptEndpoint(IPdfService pdfService, ILogger<UploadReceiptEndpoint> logger) : Endpoint<UploadReceiptRequest, EmptyResponse>
{
    public override async Task HandleAsync(UploadReceiptRequest req, CancellationToken ct)
    {
        await pdfService.AddShoppingsFromFile(req.File);
    }
}
