using Catalog.API.Features.Genres.DTOs;
using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Genres.Queries;

public sealed class GetAllGenresQueryHandler : IQueryHandler<GetAllGenresQuery, IEnumerable<GetGenreDto>>
{
    private readonly IChinookRepository _repository;

    public GetAllGenresQueryHandler(IChinookRepository repository)
    {
        _repository = repository;
    }    

    public async Task<IEnumerable<GetGenreDto>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllGenresAsync();
    }
}
