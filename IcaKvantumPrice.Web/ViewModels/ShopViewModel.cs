using System.ComponentModel.DataAnnotations;

namespace IcaKvantumPrice.Web.ViewModels;

public class ShopViewModel
{
    [Required]
    [MinLength(10, ErrorMessage = "Product Identifier is too short")]
    [MaxLength(15, ErrorMessage = "Product Identifier too long (15 character limit)")]
    public string? ProductIdentifier { get; set; }

    [MaxLength(50, ErrorMessage = "Description too long (50 character limit")]
    public string? Description { get; set; }

    [Required]
    public double? Price { get; set; }

    [Required]
    public DateTime? ShoppingDate { get; set; }
}
