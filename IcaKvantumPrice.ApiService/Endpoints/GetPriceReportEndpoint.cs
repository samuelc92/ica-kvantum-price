using FastEndpoints;
using IcaKvantumPrice.ApiService.Services;
using Microsoft.AspNetCore.Authorization;

namespace IcaKvantumPrice.ApiService.Endpoint;

[HttpGet("price-report"), AllowAnonymous]
public class GetPriceReportEndpoint(IShoppingService shoppingService) : Endpoint<EmptyRequest, ICollection<ProductPriceReport>>
{
    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var report = await shoppingService.GetPriceReportAsync();
        await SendOkAsync(report, ct);
    }
}
