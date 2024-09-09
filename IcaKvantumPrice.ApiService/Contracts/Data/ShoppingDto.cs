namespace IcaKvantumPrice.ApiService.Contracts.Data;

public record ShoppingDto(string Id, string ProductIdentifier, string Description, double Price, DateTime ShoppingDate);
