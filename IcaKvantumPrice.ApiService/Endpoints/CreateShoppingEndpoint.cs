using FastEndpoints;
using IcaKvantumPrice.ApiService.Contracts.Requests;
using IcaKvantumPrice.ApiService.Contracts.Responses;
using Microsoft.AspNetCore.Authorization;

namespace IcaKvantumPrice.ApiService.Endpoints;

[HttpPost("shoppings"), AllowAnonymous]
public class CreateShoppingEndpoint(ILogger<CreateShoppingEndpoint> logger) : Endpoint<CreateShoppingRequest, ShoppingResponse>
{
    public override Task HandleAsync(CreateShoppingRequest req, CancellationToken ct)
    {
        logger.LogInformation("Start creating shopping endpoint with request {@Request}", req);
        return base.HandleAsync(req, ct);
    }
}
