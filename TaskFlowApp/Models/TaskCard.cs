
public class TaskCard
{
    public int CardNumber { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Priority Priority { get; set; }
    public TaskStatus Status { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
}