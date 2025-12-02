using Catalog.API.Common;
using Catalog.API.Features.Genres.DTOs;

namespace Catalog.API.Features.Genres.Queries;

public sealed class GetAllGenresQuery : IQuery<IEnumerable<GetGenreDto>>
{
}
