using MediatR;

namespace Sample.Application.DBCommands
{
    public interface IDBCommand: IRequest
    {
    }

    public interface IDBQuery<out T>: IRequest<T>
    {
    }
}
