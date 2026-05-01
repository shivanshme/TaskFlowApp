using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("tasks/")]
public class TasksController : ControllerBase
{
    private readonly TaskService _service;

    public TasksController(TaskService service)
    {
        _service = service;
    }

    [HttpPost("createCard")]
    public async Task<IActionResult> CreateCard(TaskCard task)
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
}