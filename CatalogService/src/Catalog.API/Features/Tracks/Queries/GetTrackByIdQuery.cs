using Catalog.API.Common;
using Catalog.API.Features.Tracks.DTOs;

namespace Catalog.API.Features.Tracks.Queries;

public sealed record GetTrackByIdQuery(int Id) : IQuery<GetTrackDto>;
