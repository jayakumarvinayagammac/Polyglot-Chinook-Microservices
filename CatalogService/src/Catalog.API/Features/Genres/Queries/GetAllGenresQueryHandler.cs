using Catalog.API.Features.Genres.DTOs;
using Catalog.API.Common;
using Catalog.API.Features.Genres.Services;

namespace Catalog.API.Features.Genres.Queries;

public sealed class GetAllGenresQueryHandler : IQueryHandler<GetAllGenresQuery, IEnumerable<GetGenreDto>>
{
    private readonly IGenreService _service;

    public GetAllGenresQueryHandler(IGenreService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<GetGenreDto>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAllAsync();
    }
}
