using Microsoft.AspNetCore.Http;

namespace FAIT.Application.Dto.User;

public class ChangeProfileImageDto
{
    public IFormFile File { get; set; }
}