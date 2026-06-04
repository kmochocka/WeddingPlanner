using WeddingPlanner.SharedKernel.DTOs;

public interface ITaskService
{
    Task<IEnumerable<TaskDto>> GetTasksAsync();
    Task AddTaskAsync(CreateTaskDto dto);
    Task ToggleCompleteAsync(int id);
}