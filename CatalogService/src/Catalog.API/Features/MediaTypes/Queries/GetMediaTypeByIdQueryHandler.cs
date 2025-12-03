using Catalog.API.Features.MediaTypes.DTOs;
using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.MediaTypes.Queries;

public sealed class GetMediaTypeByIdQueryHandler : IQueryHandler<GetMediaTypeByIdQuery, GetMediaTypeDto>
{
    private readonly IChinookRepository _repository;

    public GetMediaTypeByIdQueryHandler(IChinookRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetMediaTypeDto> Handle(GetMediaTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetMediaTypeByIdAsync(request.Id);
        return result ?? throw new KeyNotFoundException($"MediaType with id {request.Id} not found.");
    }
}
