using WeddingPlanner.SharedKernel.DTOs;

public interface IGuestService
{
    Task<IEnumerable<GuestDto>> GetAllAsync();
    Task AddAsync(CreateGuestDto dto);
    Task DeleteAsync(int id);
}