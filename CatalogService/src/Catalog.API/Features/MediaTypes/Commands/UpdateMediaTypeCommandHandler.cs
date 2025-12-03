using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.MediaTypes.Commands;

public sealed class UpdateMediaTypeCommandHandler : ICommandHandler<UpdateMediaTypeCommand, bool>
{
    private readonly IChinookRepository _repository;

    public UpdateMediaTypeCommandHandler(IChinookRepository repository) => _repository = repository;

    public async Task<bool> Handle(UpdateMediaTypeCommand request, CancellationToken cancellationToken)
    {
        return await _repository.UpdateMediaTypeAsync(request.Id, request.Name);
    }
}
