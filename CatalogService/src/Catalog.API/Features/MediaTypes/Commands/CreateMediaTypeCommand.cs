using Catalog.API.Common;
using Catalog.API.Features.MediaTypes.DTOs;

namespace Catalog.API.Features.MediaTypes.Commands;

public sealed record CreateMediaTypeCommand(CreateMediaTypeDto MediaType) : ICommand<GetMediaTypeDto>;
