using IcaKvantumPrice.Web.ViewModels;
using Microsoft.AspNetCore.Components;

namespace IcaKvantumPrice.Web.Components.Custom;

public partial class UploadKvittoShopping
{
    [Inject]
    public ShoppingApiClient ApiClient { get; set; }
    
    [SupplyParameterFromForm]
    private KvittoShoppingViewModel _shoppingViewModel { get; set; } = new();

    private async Task HandleValidSubmit()
    {
        await ApiClient.UploadKvitto(_shoppingViewModel);
    }
}
