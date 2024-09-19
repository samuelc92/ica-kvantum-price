using IcaKvantumPrice.ApiService.Shoppings;
using IcaKvantumPrice.ApiService.Shoppings.CreateShopping;

namespace IcaKvantumPrice.ApiService.Mapping;

public static class DomainToApiContractMapper
{
    public static ShoppingResponse ToShoppingResponse(this Shopping shopping)
    {
        return new ShoppingResponse(shopping.Id, shopping.ProductIdentifier, shopping.Description, shopping.Price, shopping.ShoppingDate);
    }
}
