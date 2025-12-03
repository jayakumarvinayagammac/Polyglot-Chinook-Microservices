using Catalog.API.Features.Genres.DTOs;
using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Genres.Queries;

public sealed class GetGenreByIdQueryHandler : IQueryHandler<GetGenreByIdQuery, GetGenreDto>
{
    private readonly IChinookRepository _repository;

    public GetGenreByIdQueryHandler(IChinookRepository repository)
    {
        _repository = repository;
    }    

    public async Task<GetGenreDto> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
    {
        var genre = await _repository.GetGenreByIdAsync(request.Id);
        return genre ?? throw new KeyNotFoundException($"Genre with id {request.Id} not found.");
    }
}
