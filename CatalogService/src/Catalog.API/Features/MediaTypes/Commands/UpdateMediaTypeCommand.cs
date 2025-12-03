using Catalog.API.Common;

namespace Catalog.API.Features.MediaTypes.Commands;

public sealed record UpdateMediaTypeCommand(int Id, string Name) : ICommand<bool>;
