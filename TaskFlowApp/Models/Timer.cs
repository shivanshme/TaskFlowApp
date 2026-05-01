namespace TaskFlowApp.Models
{
    public class Timer
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public long Duration { get; set; } // in seconds
        public long Elapsed { get; set; } // in seconds
        public required string Status { get; set; } // "Active", "Paused", "Completed"
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
