using Catalog.API.Common;

namespace Catalog.API.Features.Albums.Commands;

public sealed record DeleteAlbumCommand(int Id) : ICommand<bool>;
