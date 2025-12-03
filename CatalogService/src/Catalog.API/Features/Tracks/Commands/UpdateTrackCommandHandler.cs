using Catalog.API.Common;
using Catalog.API.Features.Tracks.DTOs;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Tracks.Commands;

public sealed class UpdateTrackCommandHandler : ICommandHandler<UpdateTrackCommand, bool>
{
    private readonly IChinookRepository _repository;

    public UpdateTrackCommandHandler(IChinookRepository repository) => _repository = repository;

    public async Task<bool> Handle(UpdateTrackCommand request, CancellationToken cancellationToken)
    {
        var dto = new GetTrackDto
        {
            Name = request.Track.Name,
            AlbumId = request.Track.AlbumId,
            GenreId = request.Track.GenreId,
            MediaTypeId = request.Track.MediaTypeId,
            Milliseconds = request.Track.Milliseconds,
            UnitPrice = request.Track.UnitPrice
        };

        return await _repository.UpdateTrackAsync(request.Id, dto);
    }
}
