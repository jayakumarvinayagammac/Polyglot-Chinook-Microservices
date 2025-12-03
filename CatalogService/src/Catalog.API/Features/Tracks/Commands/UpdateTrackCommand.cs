using Catalog.API.Common;
using Catalog.API.Features.Tracks.DTOs;

namespace Catalog.API.Features.Tracks.Commands;

public sealed record UpdateTrackCommand(int Id, CreateTrackDto Track) : ICommand<bool>;
