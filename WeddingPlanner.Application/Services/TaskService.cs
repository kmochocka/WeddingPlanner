using AutoMapper;
using WeddingPlanner.SharedKernel.DTOs;
using WeddingPlanner.Domain.Entities;
using WeddingPlanner.Domain.Interfaces;
public class TaskService : ITaskService
{
    private readonly ITaskRepository _repo; private readonly IMapper _mapper;
    public TaskService(ITaskRepository repo, IMapper mapper) => (_repo, _mapper) = (repo, mapper);

    public async Task<IEnumerable<TaskDto>> GetTasksAsync() => _mapper.Map<IEnumerable<TaskDto>>(await _repo.GetAllAsync());
    public async Task AddTaskAsync(CreateTaskDto dto) => await _repo.AddAsync(_mapper.Map<TaskItem>(dto));
    public async Task ToggleCompleteAsync(int id)
    {
        var task = await _repo.GetByIdAsync(id);
        if (task != null) { task.IsCompleted = !task.IsCompleted; await _repo.UpdateAsync(task); }
    }
}