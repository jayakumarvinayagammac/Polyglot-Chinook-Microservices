using Catalog.API.Common;
using Catalog.API.Features.Artists.DTOs;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Artists.Queries
{
    public sealed class GetAllArtistQueryHandler : IQueryHandler<GetAllArtistQuery, IEnumerable<GetArtistDto>>
    {
        private readonly IChinookRepository _repository;

        public GetAllArtistQueryHandler(IChinookRepository repository)
        {
            _repository = repository;
        }
        

        public async Task<IEnumerable<GetArtistDto>> Handle(GetAllArtistQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllArtistsAsync();
        }
    }
}