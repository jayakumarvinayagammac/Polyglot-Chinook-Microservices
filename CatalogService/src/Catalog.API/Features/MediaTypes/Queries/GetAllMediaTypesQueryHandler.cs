using Catalog.API.Features.MediaTypes.DTOs;
using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.MediaTypes.Queries;

public sealed class GetAllMediaTypesQueryHandler : IQueryHandler<GetAllMediaTypesQuery, IEnumerable<GetMediaTypeDto>>
{
    private readonly IChinookRepository _repository;


    public GetAllMediaTypesQueryHandler(IChinookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GetMediaTypeDto>> Handle(GetAllMediaTypesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllMediaTypesAsync();
    }
}
