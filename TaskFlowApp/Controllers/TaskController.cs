using Microsoft.AspNetCore.Mvc;
using TaskFlowApp.Data;

[ApiController]
[Route("tasks/")]
public class TasksController : ControllerBase
{
    private readonly TaskService _service;
    private readonly AppDbContext _context;

    public TasksController(TaskService service, AppDbContext context)
    {
        _service = service;
        _context = context;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCard([FromBody] TaskCard task)
    {
        var result = await _service.CreateTask(task);
        return Ok(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAllCards(Guid userId)
    {
        var tasks = await _service.GetTasks(userId);
        return Ok(tasks);
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateStatusDto dto)
    {
    var task = await _context.Set<TaskCard>().FindAsync(id);
    if (task == null) return NotFound();
    task.Status = dto.Status;
    await _context.SaveChangesAsync();
    return Ok(task);
    }


    public class UpdateStatusDto
   {
    public TaskStatus Status { get; set; }
   }
}