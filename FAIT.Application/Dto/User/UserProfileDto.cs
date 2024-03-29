namespace FAIT.Application.Dto.User;

public class UserProfileDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NickName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Image { get; set; }
    public string Bio { get; set; }
}