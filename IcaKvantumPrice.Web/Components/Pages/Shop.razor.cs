using Microsoft.FluentUI.AspNetCore.Components;

namespace IcaKvantumPrice.Web.Components.Pages;

public partial class Shop
{
    string? activeid = "tab-1";
    FluentTab? changedto;

    private void HandleOnTabChange(FluentTab tab)
    {
        changedto = tab;
    }
}
