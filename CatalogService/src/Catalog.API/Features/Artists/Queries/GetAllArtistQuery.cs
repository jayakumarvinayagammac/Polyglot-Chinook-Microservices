using Catalog.API.Common;
using Catalog.API.Features.Artists.DTOs;

namespace Catalog.API.Features.Artists.Queries
{
    public sealed class IGetAllArtistQuery : IQuery<IEnumerable<GetArtistDto>>
    {
    }
}