using System;

namespace Sample.Application.Commands
{
    public abstract class CommandBase : ICommand
    {
        public Guid CommandId { get; }

        protected CommandBase()
        {
            CommandId = Guid.NewGuid();
        }

        protected CommandBase(Guid id)
        {
            CommandId = id;
        }
    }

    public abstract class QueryBase<TResult> : ICommand<TResult>
    {
        public Guid Id { get; }

        protected QueryBase()
        {
            Id = Guid.NewGuid();
        }

        protected QueryBase(Guid id)
        {
            Id = id;
        }
    }
}
