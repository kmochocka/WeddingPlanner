namespace WeddingPlanner.SharedKernel.DTOs;

public interface IExpenseService
{
    Task<IEnumerable<ExpenseDto>> GetAllAsync();
    Task AddAsync(CreateExpenseDto dto);
    Task TogglePaidAsync(int id);
}