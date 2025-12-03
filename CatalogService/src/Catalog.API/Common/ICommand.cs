using MediatR;

namespace Catalog.API.Common
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
        where TResponse : notnull
    {
    }
}