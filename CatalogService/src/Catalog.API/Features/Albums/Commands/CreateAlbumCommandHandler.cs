using Catalog.API.Common;
using Catalog.API.Features.Albums.DTOs;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Albums.Commands;

public sealed class CreateAlbumCommandHandler : ICommandHandler<CreateAlbumCommand, GetAlbumDto>
{
    private readonly IChinookRepository _repository;

    public CreateAlbumCommandHandler(IChinookRepository repository) => _repository = repository;

    public async Task<GetAlbumDto> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
    {
        var id = await _repository.InsertAlbumAsync(request.Album.Title, request.Album.ArtistId);
        var created = await _repository.GetAlbumByIdAsync((int)id);
        return created ?? new GetAlbumDto { AlbumId = (int)id, Title = request.Album.Title, ArtistId = request.Album.ArtistId };
    }
}
