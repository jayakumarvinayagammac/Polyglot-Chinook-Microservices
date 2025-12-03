using Catalog.API.Common;
using Catalog.API.Features.Artists.DTOs;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Artists.Queries
{
    public sealed class GetArtistByIdQueryHandler : IQueryHandler<GetArtistByIdQuery, GetArtistDto>
    {
        private readonly IChinookRepository _repository;

        public GetArtistByIdQueryHandler(IChinookRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetArtistDto> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
        {
            var artist =  await _repository.GetArtistByIdAsync(request.Id);
            return artist ?? new GetArtistDto { ArtistId = request.Id, Name = "Unknown Artist" };
        }
    }
}