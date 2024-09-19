using IcaKvantumPrice.ApiService.Database;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.Results;
using IcaKvantumPrice.ApiService.Shoppings;

namespace IcaKvantumPrice.ApiService.Services;

public class ShoppingService(DatabaseContext database) : IShoppingService
{
    public async Task CreateAsync(Shopping shopping)
    {
        var existingShopping = await database.Shoppings.Where(p => p.Id == shopping.Id).FirstOrDefaultAsync();
        if (existingShopping is not null)
        {
            var message = $"A shopping with id {shopping.Id} already exists";
            throw new ValidationException(message,
            [
                new ValidationFailure(nameof(Shopping), message)
            ]);
        }

        database.Shoppings.Add(shopping);
        await database.SaveChangesAsync();
    }

    public async Task<ICollection<ProductPriceReport>> GetPriceReportAsync()
    {
        var shoppings = await database.Shoppings.OrderBy(s => s.ShoppingDate).ToListAsync();
        var productPriceDic = new Dictionary<string, List<double>>();
        var result = new List<ProductPriceReport>();

        shoppings.ForEach(shopping =>
        {
            var hasKey = productPriceDic.TryGetValue(shopping.ProductIdentifier, out var value);
            if (hasKey)
                value?.Add(shopping.Price);
            else
                productPriceDic.Add(shopping.ProductIdentifier, [shopping.Price]);
        });

        foreach (var item in productPriceDic)
        {
            var description = shoppings.First(p => p.ProductIdentifier.Equals(item.Key)).Description;
            var newPrice = item.Value.Last();
            var oldPrice = item.Value.First();
            var percentage = ((newPrice - oldPrice) / oldPrice) * 100;

            if (percentage != 0)
                result.Add(new ProductPriceReport(item.Key, description, double.Round(percentage, 2)));
        }

        return result;
    }
}

public record ProductPriceReport(string ProductIdentifier, string Description, double Porcentage);
