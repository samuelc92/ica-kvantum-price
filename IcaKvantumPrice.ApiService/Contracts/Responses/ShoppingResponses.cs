namespace IcaKvantumPrice.ApiService.Contracts.Responses;

public record ShoppingResponse(Guid Id, string ProductIdentifier, string Description, double Price, DateTime ShoppingDate);
