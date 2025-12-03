using Catalog.API.Common;

namespace Catalog.API.Features.Albums.Commands;

public sealed record UpdateAlbumCommand(int Id, string Title, int ArtistId) : ICommand<bool>;
