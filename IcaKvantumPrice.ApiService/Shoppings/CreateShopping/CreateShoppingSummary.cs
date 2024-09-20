using FastEndpoints;

namespace IcaKvantumPrice.ApiService.Shoppings.CreateShopping;

public class CreateShoppingSummary : Summary<CreateShoppingEndpoint>
{
    public CreateShoppingSummary()
    {
        Summary = "Creates a new shopping in the system";
        Description = "Creates a new shopping in the system";
        Response<ShoppingResponse>(201, "Shopping was successfully created");
    }
}
