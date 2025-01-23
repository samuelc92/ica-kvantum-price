using FastEndpoints;
using IcaKvantumPrice.ApiService.Services;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.Metrics;

namespace IcaKvantumPrice.ApiService.Shoppings.GetPrice;

[HttpGet("price-report"), AllowAnonymous]
public class GetPriceReportEndpoint(IShoppingService shoppingService, IMeterFactory meterFactory) : Endpoint<EmptyRequest, ICollection<ProductPriceReport>>
{
    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var report = await shoppingService.GetPriceReportAsync();

        var meter = meterFactory.Create("GetPriceReport");
        var instrument = meter.CreateCounter<int>("get_price_counter");
        instrument.Add(1);

        await SendOkAsync(report, ct);
    }
}
