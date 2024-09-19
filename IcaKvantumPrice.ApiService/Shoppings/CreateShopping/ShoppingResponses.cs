namespace IcaKvantumPrice.ApiService.Shoppings.CreateShopping;

public record ShoppingResponse(Guid Id, string ProductIdentifier, string Description, double Price, DateTime ShoppingDate);
