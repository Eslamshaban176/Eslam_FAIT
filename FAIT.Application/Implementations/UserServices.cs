using FAIT.Application.Abstraction;
using FAIT.Application.Dto.User;
using FAIT.Domain.User;
using FAIT.Persistence.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FAIT.Application.Implementations;

public class UserServices : IUserServices
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<AppUser> _userManager;

    public UserServices(ApplicationDbContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }


    public async Task AddUser(AddUserDto userDto)
    {
        // check if username exists in database or not
        var isUserNameExistOrNot =
            await _context.Users.AnyAsync(us => us.NormalizedUserName == userDto.UserName.ToUpper());
        if (isUserNameExistOrNot)
            throw new AggregateException("Username is already exist");

        // check if email exists in database or not
        var isEmailExistOrNot = await _context.Users.AnyAsync(us => us.NormalizedEmail == userDto.Email.ToUpper());
        if (isEmailExistOrNot)
            throw new AggregateException("Email is already exist");

        AppUser user = new()
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            UserName = userDto.UserName,
            Email = userDto.Email,
        };


        var result = await _userManager.CreateAsync(user, userDto.Password);

        if (result.Succeeded) return;


        var error = string.Join(", ", result.Errors.Select(x => x.Description));
        throw new AggregateException(error);
    }

    public async Task<UserProfileDto> GetUserProfile(Guid userId)
    {
        var userProfile = await _context.Users.Select(user => new UserProfileDto()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            NickName = user.NickName,
            Email = user.Email,
            UserName = user.UserName,
            Bio = user.Bio,
            Image = user.Image,
            Id = user.Id
        }).FirstOrDefaultAsync(user => user.Id == userId);

        if (userProfile == null)
            throw new AggregateException(userId + " Not Found!");

        return userProfile;
    }

    public Task ChangeProfileImage(Guid userId, IFormFile file)
    {
        throw new NotImplementedException();
    }
}