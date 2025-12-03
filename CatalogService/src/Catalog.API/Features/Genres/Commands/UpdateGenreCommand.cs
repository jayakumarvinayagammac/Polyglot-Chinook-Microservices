using Catalog.API.Common;

namespace Catalog.API.Features.Genres.Commands;

public sealed record UpdateGenreCommand(int Id, string Name) : ICommand<bool>;
