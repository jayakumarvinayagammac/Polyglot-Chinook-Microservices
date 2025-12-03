using Catalog.API.Common;
using Catalog.API.Features.Artists.DTOs;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Artists.Commands;

public sealed class CreateArtistCommandHandler : ICommandHandler<CreateArtistCommand, GetArtistDto>
{
    private readonly IChinookRepository _repository;

    public CreateArtistCommandHandler(IChinookRepository repository) => _repository = repository;

    public async Task<GetArtistDto> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
    {
        var id = await _repository.InsertArtistAsync(request.Artist.Name);
        var created = await _repository.GetArtistByIdAsync((int)id);
        return created ?? new GetArtistDto { ArtistId = (int)id, Name = request.Artist.Name };
    }
}
