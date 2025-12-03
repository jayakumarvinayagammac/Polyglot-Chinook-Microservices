using Catalog.API.Common;

namespace Catalog.API.Features.Genres.Commands;

public sealed record DeleteGenreCommand(int Id) : ICommand<bool>;

