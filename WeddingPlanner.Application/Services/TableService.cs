using AutoMapper;
using WeddingPlanner.SharedKernel.DTOs;
using WeddingPlanner.Domain.Interfaces;
public class TableService : ITableService
{
    private readonly ITableRepository _repo; private readonly IMapper _mapper;
    public TableService(ITableRepository repo, IMapper mapper) => (_repo, _mapper) = (repo, mapper);

    public async Task<IEnumerable<TableDto>> GetAllAsync() => _mapper.Map<IEnumerable<TableDto>>(await _repo.GetAllAsync());
    public async Task CreateTableAsync(CreateTableDto dto) => await _repo.AddAsync(_mapper.Map<Table>(dto));
    public async Task MoveTableAsync(int id, double x, double y)
    {
        var table = await _repo.GetByIdAsync(id);
        if (table != null) { table.PositionX = x; table.PositionY = y; await _repo.UpdateAsync(table); }
    }
}