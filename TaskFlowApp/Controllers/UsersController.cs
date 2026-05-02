using Microsoft.AspNetCore.Mvc;
using TaskFlowApp.Data;
using TaskFlowApp.Models;

namespace TaskFlowApp.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Users.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
