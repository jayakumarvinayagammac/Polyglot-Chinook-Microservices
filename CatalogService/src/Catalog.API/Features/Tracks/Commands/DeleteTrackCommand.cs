using Catalog.API.Common;

namespace Catalog.API.Features.Tracks.Commands;

public sealed record DeleteTrackCommand(int Id) : ICommand<bool>;
