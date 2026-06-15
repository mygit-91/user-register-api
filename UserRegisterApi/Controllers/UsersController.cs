using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserRegisterApi.Entities;
using UserRegisterApi.Entities.Data;
using UserRegisterApi.Entities.Model;

[Route("api/[controller]")]
[ApiController]
public class UsersController(AppDBContext _context) : ControllerBase
{
    [HttpGet("getUser")]
    public async Task<ActionResult<IEnumerable<User>>> GetUser()
    {
        return await _context.User.ToListAsync();
    }

    [HttpPost("addUser")]
    public async Task<ActionResult<User>> AddUser(UserModel userData)
    {
        // Add user
        User user = new()
        {
            FirstName = userData.FirstName,
            LastName = userData.LastName,
            Email = userData.Email,
            Phone = userData.Phone,
            Profile = userData.Profile,
            BirthDay = userData.BirthDay,
            Occupation = userData.Occupation,
            Sex = userData.Sex
        };

        _context.User.Add(user);
        await _context.SaveChangesAsync();

        var result = CreatedAtAction("GetUser", new { userid = user.UserId }, user);
        return Ok(result.Value);
    }
}
