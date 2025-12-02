using Catalog.API.Features.Artists.DTOs;
using Catalog.API.Infrastructure;
using Catalog.API.Models;

namespace Catalog.API.Features.Artists.Services;

public class ArtistService : IArtistService
{
    private IChinookRepository chinookRepository;
    public ArtistService(IChinookRepository repository)
    {
        chinookRepository = repository;
    }
    public async Task<IEnumerable<GetArtistDto>> GetAllAsync()
    {
        return await chinookRepository.GetAllArtistsAsync();
    }

    public async Task<GetArtistDto?> GetByIdAsync(int id)
    {
        return await chinookRepository.GetArtistByIdAsync(id);
    }

    public async Task<GetArtistDto> CreateAsync(CreateArtistDto dto)
    {
        var artistId = await chinookRepository.InsertArtistAsync(dto.Name);
        var createdArtist = await chinookRepository.GetArtistByIdAsync((int)artistId);
        return createdArtist ?? new GetArtistDto { ArtistId = (int)artistId, Name = dto.Name };
    }

    public async Task<bool> UpdateAsync(int id, CreateArtistDto dto)
    {
        return await chinookRepository.UpdateArtistAsync(id, dto.Name);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await chinookRepository.DeleteArtistAsync(id);
    }
}
