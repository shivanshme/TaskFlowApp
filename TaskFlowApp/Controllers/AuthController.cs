using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskFlowApp.Data;
using TaskFlowApp.Models;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        var exists = await _context.Users
            .AnyAsync(u => u.Email == user.Email);

        if (exists)
            return BadRequest("User already exists");

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(user);
    }
}