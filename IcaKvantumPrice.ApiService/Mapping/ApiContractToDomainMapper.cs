using IcaKvantumPrice.ApiService.Shoppings;
using IcaKvantumPrice.ApiService.Shoppings.CreateShopping;

namespace IcaKvantumPrice.ApiService.Mapping;

public static class ApiContractToDomainMapper
{
    public static Shopping ToShopping(this CreateShoppingRequest request)
    {
        return new Shopping
        {
            ProductIdentifier = request.ProductIdentifier,
            Description = request.Description,
            Price = request.Price,
            ShoppingDate = request.ShoppingDate,
        };
    }
}
