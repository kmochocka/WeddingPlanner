using WeddingPlanner.Domain.Entities; 
namespace WeddingPlanner.Domain.Interfaces;

public interface IBudgetRepository
{

    Task<WeddingBudget> GetBudgetAsync();
    Task UpdateAsync(WeddingBudget budget);
}