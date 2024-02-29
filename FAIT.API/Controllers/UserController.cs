using FAIT.Application.Abstraction;
using FAIT.Application.Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace FAIT.API.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController: ControllerBase
{
    private readonly IUserServices _userServices;

    public UserController(IUserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpGet]
    [Route("{id:guid}/profile")]
    public async Task<ActionResult> GetPtofileInfo([FromRoute] Guid id)
    {
        try
        {
            var user = await _userServices.GetUserProfile(id);
            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult>  AddUser([FromBody] AddUserDto userDto)
    {
        try
        {
            await _userServices.AddUser(userDto);
            return Created();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpPost("{id:guid}/change-profile-image")]
    public async Task<ActionResult> Change(Guid id,[FromForm] ChangeProfileImageDto dto)
    {
        try
        {
            await _userServices.ChangeProfileImage(id, dto.File);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}