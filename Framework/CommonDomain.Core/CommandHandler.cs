using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain.Persistence;

namespace CommonDomain.Core
{

    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        CommandValidation Execute(TCommand command, ICommandHandler<TCommand> next);
    }

    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        protected IRepository Repository;
        public abstract CommandValidation Execute(TCommand command, ICommandHandler<TCommand> next);

        public CommandHandler(IRepository repository)
        {
            Contract.Requires<ArgumentNullException>(repository != null);

            Repository = repository;
        }
    }

    public static class CustomHandler
    {
        public static void Add<T>(Dictionary<Type, Func<ICommand, CommandValidation>> dictionnary, ICommandHandler<T> finalHandler) where T : ICommand
        {
            dictionnary.Add(typeof(T), (cmd) => new ReadOnce<T>().Execute((T)cmd, finalHandler));
        }
    }

    public class ReadOnce<T> : ICommandHandler<T> where T : ICommand
    {

        public CommandValidation Execute(T command, ICommandHandler<T> next)
        {
            return next.Execute(command, next);
        }
    }

}
