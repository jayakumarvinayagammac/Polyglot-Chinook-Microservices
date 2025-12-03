using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Artists.Commands;

public sealed class DeleteArtistCommandHandler : ICommandHandler<DeleteArtistCommand, bool>
{
    private readonly IChinookRepository _repository;

    public DeleteArtistCommandHandler(IChinookRepository repository) => _repository = repository;

    public async Task<bool> Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteArtistAsync(request.Id);
    }
}
