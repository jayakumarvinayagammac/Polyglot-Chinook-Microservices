using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Tracks.Commands;

public sealed class DeleteTrackCommandHandler : ICommandHandler<DeleteTrackCommand, bool>
{
    private readonly IChinookRepository _repository;

    public DeleteTrackCommandHandler(IChinookRepository repository) => _repository = repository;

    public async Task<bool> Handle(DeleteTrackCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteTrackAsync(request.Id);
    }
}
