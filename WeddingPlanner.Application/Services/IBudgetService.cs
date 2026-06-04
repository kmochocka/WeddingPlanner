using WeddingPlanner.SharedKernel.DTOs;
using WeddingPlanner.Domain.Entities;

namespace WeddingPlanner.Application.Services; 

public interface IBudgetService
{
    Task<BudgetDto> GetBudgetAsync();
    Task UpdateBudgetAsync(decimal amount);
}