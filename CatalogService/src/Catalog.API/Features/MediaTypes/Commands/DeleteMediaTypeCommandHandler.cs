using Catalog.API.Common;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.MediaTypes.Commands;

public sealed class DeleteMediaTypeCommandHandler : ICommandHandler<DeleteMediaTypeCommand, bool>
{
    private readonly IChinookRepository _repository;

    public DeleteMediaTypeCommandHandler(IChinookRepository repository) => _repository = repository;

    public async Task<bool> Handle(DeleteMediaTypeCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteMediaTypeAsync(request.Id);
    }
}
