using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Domain;

public class User : IdentityUser // Part of the ASP Net core identity Model
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Phone { get; set; }
    public string? AvatarUrl { get; set; }
    public bool IsActive { get; set; }

}