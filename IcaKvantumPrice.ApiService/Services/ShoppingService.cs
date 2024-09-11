using IcaKvantumPrice.ApiService.Database;
using IcaKvantumPrice.ApiService.Domain;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.Results;

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
}
