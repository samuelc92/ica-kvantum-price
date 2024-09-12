using IcaKvantumPrice.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace IcaKvantumPrice.Web.Components.Custom;

public partial class UploadKvittoShopping
{
    [Inject]
    public ShoppingApiClient ApiClient { get; set; }

    [Inject]
    public IToastService ToastService { get; set; }
    
    [SupplyParameterFromForm]
    private KvittoShoppingViewModel _shoppingViewModel { get; set; } = new();

    private async Task HandleValidSubmit()
    {
        try
        {
            await ApiClient.UploadKvitto(_shoppingViewModel);
            ToastService.ShowSuccess("Kvitto was uploaded successfully.");
        }
        catch
        {
            ToastService.ShowError("Failed to upload the kvitto");
        }
    }
}
