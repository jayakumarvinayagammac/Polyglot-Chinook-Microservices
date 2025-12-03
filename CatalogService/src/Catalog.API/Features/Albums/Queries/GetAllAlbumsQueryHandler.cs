using Catalog.API.Features.Albums.DTOs;
using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Albums.Queries;

public sealed class GetAllAlbumsQueryHandler : IQueryHandler<GetAllAlbumsQuery, IEnumerable<GetAlbumDto>>
{
    private readonly IChinookRepository _repository;


    public GetAllAlbumsQueryHandler(IChinookRepository chinookRepository)
    {
        _repository = chinookRepository;
    }

    public async Task<IEnumerable<GetAlbumDto>> Handle(GetAllAlbumsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAlbumsAsync();
    }
}
