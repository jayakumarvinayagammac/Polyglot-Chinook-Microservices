using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Genres.Commands;

public sealed class DeleteGenreCommandHandler : ICommandHandler<DeleteGenreCommand, bool>
{
    private readonly IChinookRepository _repository;

    public DeleteGenreCommandHandler(IChinookRepository repository) => _repository = repository;

    public async Task<bool> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteGenreAsync(request.Id);
    }
}
