using Catalog.API.Common;
using Catalog.API.Features.MediaTypes.DTOs;

namespace Catalog.API.Features.MediaTypes.Queries;

public sealed record GetAllMediaTypesQuery : IQuery<IEnumerable<GetMediaTypeDto>>
{
}

