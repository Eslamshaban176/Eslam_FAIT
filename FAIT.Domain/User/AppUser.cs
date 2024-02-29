using Microsoft.AspNetCore.Identity;

namespace FAIT.Domain.User;

public class AppUser: IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NickName { get; set; }
    public string Bio { get; set; }
    public string Image { get; set; }
    
}