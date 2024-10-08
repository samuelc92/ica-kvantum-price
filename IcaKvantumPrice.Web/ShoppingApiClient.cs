﻿using IcaKvantumPrice.Web.ViewModels;

namespace IcaKvantumPrice.Web;

public class ShoppingApiClient(HttpClient httpClient)
{
    public async Task PostShopping(ShopViewModel shop, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync<ShopViewModel>("/shoppings", shop, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task UploadKvitto(KvittoShoppingViewModel shoppingViewModel, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync<KvittoShoppingViewModel>("/receipts", shoppingViewModel, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task<IEnumerable<ProductPriceReportViewModel>?> GetProductPriceReportAsync(CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetFromJsonAsync<IEnumerable<ProductPriceReportViewModel>>("/price-report", cancellationToken);
        return response;
    }
}
