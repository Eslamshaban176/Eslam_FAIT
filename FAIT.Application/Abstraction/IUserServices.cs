using FAIT.Application.Dto.User;
using Microsoft.AspNetCore.Http;


namespace FAIT.Application.Abstraction;

public interface IUserServices
{
    Task AddUser(AddUserDto userDto);
    Task<UserProfileDto> GetUserProfile(Guid userId);
    Task ChangeProfileImage(Guid userId, IFormFile file);
}