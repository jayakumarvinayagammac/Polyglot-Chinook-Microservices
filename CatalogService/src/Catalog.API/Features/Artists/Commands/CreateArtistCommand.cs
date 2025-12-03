using Catalog.API.Common;
using Catalog.API.Features.Artists.DTOs;

namespace Catalog.API.Features.Artists.Commands;

public sealed record CreateArtistCommand(CreateArtistDto Artist) : ICommand<GetArtistDto>;
