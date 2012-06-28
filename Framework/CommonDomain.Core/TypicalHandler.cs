using System;
using System.Collections.Generic;

namespace CommonDomain.Core
{
    public static class TypicalHandler
    {
        public static void Add<T>(Dictionary<Type, Func<IMessage, CommandValidation>> dictionnary, ICommandHandler<T> finalHandler) where T : IMessage
        {
            dictionnary.Add(typeof(T), (cmd) => new ReadOnce<T>().Execute((T)cmd, finalHandler));
        }
    }
}