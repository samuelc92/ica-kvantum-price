using IcaKvantumPrice.Web.ViewModels;
using Microsoft.AspNetCore.Components;

namespace IcaKvantumPrice.Web.Components.Custom;

public partial class AddShopping
{

    [Inject]
    public ShoppingApiClient ApiClient { get; set; }


    [SupplyParameterFromForm]
    private ShopViewModel _shopViewModel { get; set; } = new();

    protected override void OnInitialized()
    {
        _shopViewModel.ShoppingDate = DateTime.Now;
    }

    private async Task HandleValidSubmit()
    {
        await ApiClient.PostShopping(_shopViewModel);
    }
}
