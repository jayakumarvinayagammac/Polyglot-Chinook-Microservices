using Catalog.API.Common;

namespace Catalog.API.Features.MediaTypes.Commands;

public sealed record DeleteMediaTypeCommand(int Id) : ICommand<bool>;
