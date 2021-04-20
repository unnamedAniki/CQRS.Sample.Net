using MediatR;

namespace Sample.Application.Commands
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }

    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }

}
