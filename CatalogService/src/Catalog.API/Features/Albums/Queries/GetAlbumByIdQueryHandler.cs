using Catalog.API.Features.Albums.DTOs;
using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Albums.Queries;

public sealed class GetAlbumByIdQueryHandler : IQueryHandler<GetAlbumByIdQuery, GetAlbumDto>
{
    private readonly IChinookRepository _repository;    
    public GetAlbumByIdQueryHandler(IChinookRepository chinookRepository)
    {
        _repository = chinookRepository;
    }
    public async Task<GetAlbumDto> Handle(GetAlbumByIdQuery request, CancellationToken cancellationToken)
    {
        var album = await _repository.GetAlbumByIdAsync(request.Id);
        return album ?? throw new KeyNotFoundException($"Album with id {request.Id} not found.");
    }
}