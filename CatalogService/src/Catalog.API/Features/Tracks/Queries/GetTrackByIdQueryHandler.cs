using Catalog.API.Features.Tracks.DTOs;
using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Tracks.Queries;

public sealed class GetTrackByIdQueryHandler : IQueryHandler<GetTrackByIdQuery, GetTrackDto>
{
    private readonly IChinookRepository _repository;

    public GetTrackByIdQueryHandler(IChinookRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetTrackDto> Handle(GetTrackByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetTrackByIdAsync(request.Id);
        return result ?? throw new KeyNotFoundException($"Track with id {request.Id} not found.");
    }
}
