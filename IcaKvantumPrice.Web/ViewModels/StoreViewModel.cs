using System.ComponentModel.DataAnnotations;

namespace IcaKvantumPrice.Web.ViewModels;

public class StoreViewModel
{
    public Guid Id { get; set; }

    [MaxLength(20, ErrorMessage = "Description too long (20 character limit")]
    public string? Name { get; set; }
}
