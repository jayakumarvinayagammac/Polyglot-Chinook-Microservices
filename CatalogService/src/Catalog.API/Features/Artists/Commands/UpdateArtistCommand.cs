using Catalog.API.Common;

namespace Catalog.API.Features.Artists.Commands;

public sealed record UpdateArtistCommand(int Id, string Name) : ICommand<bool>;
