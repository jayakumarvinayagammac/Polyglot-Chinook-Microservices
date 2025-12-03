using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Albums.Commands;

public sealed class UpdateAlbumCommandHandler : ICommandHandler<UpdateAlbumCommand, bool>
{
    private readonly IChinookRepository _repository;

    public UpdateAlbumCommandHandler(IChinookRepository repository) => _repository = repository;

    public async Task<bool> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
    {
        return await _repository.UpdateAlbumAsync(request.Id, request.Title, request.ArtistId);
    }
}
