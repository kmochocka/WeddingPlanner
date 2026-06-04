using AutoMapper;
using WeddingPlanner.SharedKernel.DTOs;
using WeddingPlanner.Domain.Entities;
using WeddingPlanner.Domain.Interfaces;

public class GuestService : IGuestService
{
    private readonly IGuestRepository _repo; private readonly IMapper _mapper;
    public GuestService(IGuestRepository repo, IMapper mapper) => (_repo, _mapper) = (repo, mapper);

    public async Task<IEnumerable<GuestDto>> GetAllAsync() => _mapper.Map<IEnumerable<GuestDto>>(await _repo.GetAllAsync());
    public async Task AddAsync(CreateGuestDto dto) => await _repo.AddAsync(_mapper.Map<Guest>(dto));
    public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
}