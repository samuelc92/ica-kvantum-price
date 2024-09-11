using IcaKvantumPrice.ApiService.Domain;

namespace IcaKvantumPrice.ApiService.Services;

public interface IPdfService
{
    Task AddShoppingsFromFile(string pdfPath);
}
