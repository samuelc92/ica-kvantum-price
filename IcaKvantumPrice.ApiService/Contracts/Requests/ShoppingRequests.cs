namespace IcaKvantumPrice.ApiService.Contracts.Requests;

public record CreateShoppingRequest(string ProductIdentifier, string Description, double Price, DateTime ShoppingDate);
