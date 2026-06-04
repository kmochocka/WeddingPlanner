namespace WeddingPlanner.SharedKernel.DTOs;

public class TaskDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime? DueDate { get; set; }
}

public class CreateTaskDto
{
    public string Title { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
}