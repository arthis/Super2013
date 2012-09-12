using System;
using CommonDomain.Core.Handlers;

namespace CommonDomain.Core.Tests
{
    public class MyFinalHandler<T> : IFinalHandler<T> where T : ICommand
    {
        public CommandValidation Execute(T command)
        {
         //do nothing but do it well!!
            return null;
        }

        public ISession Session { get; set; }
    }
}