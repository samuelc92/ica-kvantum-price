using IcaKvantumPrice.Web.ViewModels;

namespace IcaKvantumPrice.Web;

public class ShoppingApiClient(HttpClient httpClient)
{
    public async Task PostShopping(ShopViewModel shop, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync<ShopViewModel>("/shoppings", shop, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
