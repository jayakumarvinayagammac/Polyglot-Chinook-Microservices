using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Artists.Commands;

public sealed class UpdateArtistCommandHandler : ICommandHandler<UpdateArtistCommand, bool>
{
    private readonly IChinookRepository _repository;

    public UpdateArtistCommandHandler(IChinookRepository repository) => _repository = repository;

    public async Task<bool> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
    {
        return await _repository.UpdateArtistAsync(request.Id, request.Name);
    }
}
