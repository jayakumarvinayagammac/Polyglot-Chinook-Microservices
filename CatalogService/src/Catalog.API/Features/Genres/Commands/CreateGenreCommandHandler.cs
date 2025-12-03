using Catalog.API.Common;
using Catalog.API.Features.Genres.DTOs;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Genres.Commands;

public sealed class CreateGenreCommandHandler : ICommandHandler<CreateGenreCommand, GetGenreDto>
{
    private readonly IChinookRepository _repository;

    public CreateGenreCommandHandler(IChinookRepository repository) => _repository = repository;

    public async Task<GetGenreDto> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var id = await _repository.InsertGenreAsync(request.Name);
        var created = await _repository.GetGenreByIdAsync((int)id);
        return created ?? new GetGenreDto { GenreId = (int)id, Name = request.Name };
    }
}
