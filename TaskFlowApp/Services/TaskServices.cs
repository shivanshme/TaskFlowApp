using Microsoft.EntityFrameworkCore;
using TaskFlowApp.Data;

public class TaskService
{
    private readonly AppDbContext _context;

    public TaskService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TaskCard> CreateTask(TaskCard task)
    {
        task.CardNumber = await GetNextCardNumber(task.UserId);
        task.CreatedAt = DateTime.UtcNow;

        _context.TaskCards.Add(task);
        await _context.SaveChangesAsync(); 

        return task;
    }

    public async Task<List<TaskCard>> GetTasks(Guid userId)
    {
        return await _context.TaskCards
            .Where(t => t.UserId == userId)
            .ToListAsync();
    }

    private async Task<int> GetNextCardNumber(Guid userId)
    {
        var last = await _context.TaskCards
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.CardNumber)
            .FirstOrDefaultAsync();

        return (last?.CardNumber ?? 0) + 1;
    }
}