using AutoMapper;
using WeddingPlanner.SharedKernel.DTOs;
using WeddingPlanner.Domain.Entities;
using WeddingPlanner.Domain.Interfaces;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _repo; private readonly IMapper _mapper;
    public ExpenseService(IExpenseRepository repo, IMapper mapper) => (_repo, _mapper) = (repo, mapper);

    public async Task<IEnumerable<ExpenseDto>> GetAllAsync() => _mapper.Map<IEnumerable<ExpenseDto>>(await _repo.GetAllAsync());
    public async Task AddAsync(CreateExpenseDto dto) => await _repo.AddAsync(_mapper.Map<Expense>(dto));
    public async Task TogglePaidAsync(int id)
    {
        var exp = await _repo.GetByIdAsync(id);
        if (exp != null) { exp.IsPaid = !exp.IsPaid; await _repo.UpdateAsync(exp); }
    }
}