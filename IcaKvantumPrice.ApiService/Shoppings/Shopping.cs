namespace IcaKvantumPrice.ApiService.Shoppings;

public class Shopping
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string ProductIdentifier { get; init; } = default!;

    public string Description { get; init; } = default!;

    public double Price { get; init; }

    public DateTime ShoppingDate { get; init; }
}
