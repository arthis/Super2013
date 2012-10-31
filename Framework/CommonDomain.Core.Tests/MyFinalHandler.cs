using System;
using CommonDomain.Core.Handlers;

namespace CommonDomain.Core.Tests
{
    public class MyCommandHandlerWithSession<T> : ICommandHandler<T> where T : ICommand 
    {
        public CommandValidation Execute(T command)
        {
         //do nothing but do it well!!
            return null;
        }

        public IAction Action { get; set; }
    }
}