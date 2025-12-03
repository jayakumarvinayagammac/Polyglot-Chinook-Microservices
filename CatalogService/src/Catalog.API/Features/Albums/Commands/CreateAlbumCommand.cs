using Catalog.API.Common;
using Catalog.API.Features.Albums.DTOs;

namespace Catalog.API.Features.Albums.Commands;

public sealed record CreateAlbumCommand(CreateAlbumDto Album) : ICommand<GetAlbumDto>;
