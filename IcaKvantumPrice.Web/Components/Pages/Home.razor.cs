using IcaKvantumPrice.Web.ViewModels;
using Microsoft.AspNetCore.Components;

namespace IcaKvantumPrice.Web.Components.Pages;

public partial class Home
{
    [Inject]
    public ShoppingApiClient ApiClient { get; set; }

    private IQueryable<ProductPriceReportViewModel>? _report;

    protected override async Task OnInitializedAsync()
    {
        var report = await ApiClient.GetProductPriceReportAsync();
        _report = report?.AsQueryable();
    }
}
