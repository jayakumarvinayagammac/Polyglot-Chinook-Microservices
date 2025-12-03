using Catalog.API.Common;

namespace Catalog.API.Features.Artists.Commands;

public sealed record DeleteArtistCommand(int Id) : ICommand<bool>;
