using Catalog.API.Common;
using Catalog.API.Features.Artists.DTOs;

namespace Catalog.API.Features.Artists.Queries
{
    public sealed record GetArtistByIdQuery(int Id) : IQuery<GetArtistDto>;

    
}