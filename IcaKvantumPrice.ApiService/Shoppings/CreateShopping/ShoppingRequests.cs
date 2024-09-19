namespace IcaKvantumPrice.ApiService.Shoppings.CreateShopping;

public record CreateShoppingRequest(string ProductIdentifier, string Description, double Price, DateTime ShoppingDate);
