using WeddingPlanner.SharedKernel.DTOs;

public interface ITableService
{
    Task<IEnumerable<TableDto>> GetAllAsync();
    Task CreateTableAsync(CreateTableDto dto);
    Task MoveTableAsync(int id, double x, double y);
}