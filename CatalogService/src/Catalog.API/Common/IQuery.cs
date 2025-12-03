using MediatR;

namespace Catalog.API.Common
{
    public interface IQuery<out TResponse> : IRequest<TResponse>  
    where TResponse : notnull
    {
    }
}