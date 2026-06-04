using AutoMapper;

using WeddingPlanner.SharedKernel.DTOs;
using WeddingPlanner.Domain.Entities;
using WeddingPlanner.Domain.Interfaces;

namespace WeddingPlanner.Application.Services;
public class BudgetService : IBudgetService
{
    private readonly IBudgetRepository _repo; private readonly IMapper _mapper;
    public BudgetService(IBudgetRepository repo, IMapper mapper) => (_repo, _mapper) = (repo, mapper);

  
    public async Task<BudgetDto> GetBudgetAsync()
    {
        var weddingBudget = await _repo.GetBudgetAsync(); 
        return _mapper.Map<BudgetDto>(weddingBudget);
    }
   
    public async Task UpdateBudgetAsync(decimal amount)
    {
        var budget = await _repo.GetBudgetAsync();
        budget.TotalAmount = amount;
        await _repo.UpdateAsync(budget);
    }
}