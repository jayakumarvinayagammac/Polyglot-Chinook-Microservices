using Catalog.API.Common;
using Catalog.API.Features.Genres.DTOs;

namespace Catalog.API.Features.Genres.Commands;

public sealed record CreateGenreCommand(string Name) : ICommand<GetGenreDto>;

