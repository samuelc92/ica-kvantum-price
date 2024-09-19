using FastEndpoints;
using IcaKvantumPrice.ApiService.Mapping;
using IcaKvantumPrice.ApiService.Services;
using Microsoft.AspNetCore.Authorization;

namespace IcaKvantumPrice.ApiService.Shoppings.CreateShopping;

[HttpPost("shoppings"), AllowAnonymous]
public class CreateShoppingEndpoint(IShoppingService service, ILogger<CreateShoppingEndpoint> logger) : Endpoint<CreateShoppingRequest, ShoppingResponse>
{
    public override async Task HandleAsync(CreateShoppingRequest req, CancellationToken ct)
    {
        logger.LogInformation("Start creating shopping endpoint with request {@Request}", req);

        var shopping = req.ToShopping();
        await service.CreateAsync(shopping);
        var response = shopping.ToShoppingResponse();

        await SendAsync(response, cancellation: ct);
    }
}
