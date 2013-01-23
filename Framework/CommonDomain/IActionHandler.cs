using System;
using System.Collections.Generic;

namespace CommonDomain
{
    public interface IActionHandler
    {
        void AddCommandContrainedAction<T>() where T : ICommand;
        void AddFullyConstrainedActionHandlerFor<T>() where T : ICommand;

        bool ContainsKey(string type);
        IAction GetAction(string type);
        
    }

    
}