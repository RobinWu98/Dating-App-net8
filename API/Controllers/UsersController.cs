using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // api/users route to the name of the controller
public class UsersController(DataContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();

        return users;
    }

    [HttpGet("{id}")] //api/users/1.2.3...
    public ActionResult<AppUser> GetUsers(int id)
    {
        var user = context.Users.Find(id);

        if (user == null) return NotFound();

        return user;
    }

}