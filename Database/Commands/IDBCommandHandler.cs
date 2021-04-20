using Sample.Application.DBCommands;
using MediatR;

namespace Sample.Database.Commands
{
    public interface IDBCommandHandler<in TCommand> :
        IRequestHandler<TCommand> where TCommand : IDBCommand
    {
        
    }

    public interface IDBQueryHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult> where TCommand : IDBQuery<TResult>
    {

    }
}
