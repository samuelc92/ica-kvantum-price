using IcaKvantumPrice.ApiService.Domain;

namespace IcaKvantumPrice.ApiService.Shoppings.UploadReceipt;

public interface IPdfService
{
    Task AddShoppingsFromFile(string pdfPath);
}
