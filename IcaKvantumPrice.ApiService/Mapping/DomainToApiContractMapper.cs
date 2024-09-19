using IcaKvantumPrice.ApiService.Contracts.Responses;
using IcaKvantumPrice.ApiService.Shoppings;

namespace IcaKvantumPrice.ApiService.Mapping;

public static class DomainToApiContractMapper
{
    public static ShoppingResponse ToShoppingResponse(this Shopping shopping)
    {
        return new ShoppingResponse(shopping.Id, shopping.ProductIdentifier, shopping.Description, shopping.Price, shopping.ShoppingDate);
    }
}
