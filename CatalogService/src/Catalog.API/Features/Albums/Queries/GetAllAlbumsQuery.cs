using Catalog.API.Common;
using Catalog.API.Features.Albums.DTOs;

namespace Catalog.API.Features.Albums.Queries;

public sealed class GetAllAlbumsQuery : IQuery<IEnumerable<GetAlbumDto>>
{
}

public sealed record GetAlbumByIdQuery(int Id) : IQuery<GetAlbumDto>;
