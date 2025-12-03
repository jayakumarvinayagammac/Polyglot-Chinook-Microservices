using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Albums.Commands;

public sealed class DeleteAlbumCommandHandler : ICommandHandler<DeleteAlbumCommand, bool>
{
    private readonly IChinookRepository _repository;

    public DeleteAlbumCommandHandler(IChinookRepository repository) => _repository = repository;

    public async Task<bool> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAlbumAsync(request.Id);
    }
}
