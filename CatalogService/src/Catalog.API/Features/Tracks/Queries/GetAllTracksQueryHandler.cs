using Catalog.API.Features.Tracks.DTOs;
using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Tracks.Queries;

public sealed class GetAllTracksQueryHandler : IQueryHandler<GetAllTracksQuery, IEnumerable<GetTrackDto>>
{
    private readonly IChinookRepository _repository;
    public GetAllTracksQueryHandler(IChinookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GetTrackDto>> Handle(GetAllTracksQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllTracksAsync();
    }
}
