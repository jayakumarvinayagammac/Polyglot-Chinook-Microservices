using Catalog.API.Common;
using Catalog.API.Features.Artists.DTOs;
using Catalog.API.Features.Artists.Services;

namespace Catalog.API.Features.Artists.Queries
{
    public sealed class GetAllArtistQueryHandler : IQueryHandler<IGetAllArtistQuery, IEnumerable<GetArtistDto>>
    {
        private readonly IArtistService _service;

        public GetAllArtistQueryHandler(IArtistService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<GetArtistDto>> Handle(IGetAllArtistQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync();
        }
    }
}