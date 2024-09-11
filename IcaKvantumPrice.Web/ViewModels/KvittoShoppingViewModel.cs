using System.ComponentModel.DataAnnotations;

namespace IcaKvantumPrice.Web.ViewModels;

public class KvittoShoppingViewModel
{
    
    [Required]
    public string? File { get; set; }
}
