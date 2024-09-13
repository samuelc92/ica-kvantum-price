using System.ComponentModel;

namespace IcaKvantumPrice.Web.ViewModels;

public class ProductPriceReportViewModel
{
    [DisplayName("Product identifier")]
    public string? ProductIdentifier { get; set; }
    public string? Description { get; set; }
    public double Porcentage { get; set; }
}
