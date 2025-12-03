using Catalog.API.Common;
using Catalog.API.Features.MediaTypes.DTOs;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.MediaTypes.Commands;

public sealed class CreateMediaTypeCommandHandler : ICommandHandler<CreateMediaTypeCommand, GetMediaTypeDto>
{
    private readonly IChinookRepository _repository;

    public CreateMediaTypeCommandHandler(IChinookRepository repository) => _repository = repository;

    public async Task<GetMediaTypeDto> Handle(CreateMediaTypeCommand request, CancellationToken cancellationToken)
    {
        var id = await _repository.InsertMediaTypeAsync(request.MediaType.Name);
        var created = await _repository.GetMediaTypeByIdAsync((int)id);
        return created ?? new GetMediaTypeDto { MediaTypeId = (int)id, Name = request.MediaType.Name };
    }
}
