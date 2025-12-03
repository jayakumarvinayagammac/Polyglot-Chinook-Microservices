using Catalog.API.Common;
using Catalog.API.Features.Tracks.DTOs;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Tracks.Commands;

public sealed class CreateTrackCommandHandler : ICommandHandler<CreateTrackCommand, GetTrackDto>
{
    private readonly IChinookRepository _repository;

    public CreateTrackCommandHandler(IChinookRepository repository) => _repository = repository;

    public async Task<GetTrackDto> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
    {
        var id = await _repository.InsertTrackAsync(new GetTrackDto
        {
            Name = request.Track.Name,
            AlbumId = request.Track.AlbumId,
            GenreId = request.Track.GenreId,
            MediaTypeId = request.Track.MediaTypeId,
            Milliseconds = request.Track.Milliseconds,
            UnitPrice = request.Track.UnitPrice
        });

        var created = await _repository.GetTrackByIdAsync((int)id);
        return created ?? new GetTrackDto { TrackId = (int)id, Name = request.Track.Name };
    }
}
