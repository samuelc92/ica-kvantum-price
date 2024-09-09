using IcaKvantumPrice.ApiService.Domain;

namespace IcaKvantumPrice.ApiService.Services;

public interface IPdfService
{
    ICollection<Shopping> FetchShoppings(string pdfPath);
}
