using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Genres.Commands;

public sealed class UpdateGenreCommandHandler : ICommandHandler<UpdateGenreCommand, bool>
{
    private readonly IChinookRepository _repository;

    public UpdateGenreCommandHandler(IChinookRepository repository) => _repository = repository;

    public async Task<bool> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        return await _repository.UpdateGenreAsync(request.Id, request.Name);
    }
}
