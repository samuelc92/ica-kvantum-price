namespace IcaKvantumPrice.Web.ViewModels;

using System.ComponentModel;

public class ProductPriceReportViewModel
{
    [DisplayName("Product identifier")]
    public string? ProductIdentifier { get; set; }
    public string? Description { get; set; }
    public double Porcentage { get; set; }

    [DisplayName("Percent")]
    public string PorcentageFormatted
    {
        get
        {
            return Porcentage.ToString("F2") + "%";
        }
    }
}
