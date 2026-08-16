using MediatR;

namespace Clinical.Common.Application.Contract;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
    
}