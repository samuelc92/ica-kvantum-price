using IcaKvantumPrice.ApiService.Domain;

namespace IcaKvantumPrice.ApiService.Services;

public interface IShoppingService
{
    Task CreateAsync(Shopping shopping);
    Task<ICollection<ProductPriceReport>> GetPriceReportAsync();
}
