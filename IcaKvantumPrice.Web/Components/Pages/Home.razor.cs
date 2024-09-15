using IcaKvantumPrice.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace IcaKvantumPrice.Web.Components.Pages;

public partial class Home
{
    [Inject]
    public ShoppingApiClient ApiClient { get; set; }

    [Inject]
    public IToastService ToastService { get; set; }


    private IQueryable<ProductPriceReportViewModel>? _report;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var report = await ApiClient.GetProductPriceReportAsync();
            _report = report?.AsQueryable();
        }
        catch
        {
            ToastService.ShowError("Failed on fetching product's prices.");
        }
    }
}
