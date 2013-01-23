using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace CommonDomain.Core.Handlers.Actions
{
    public class ActionHandler : IActionHandler
    {
        private Dictionary<string, Func<IAction>> _handler;

        public ActionHandler()
        {
            _handler = new Dictionary<string, Func<IAction>>();    
        }

        public void AddFullyConstrainedActionHandlerFor<T>() where T : ICommand
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(string type)
        {
            return _handler.ContainsKey(type);
        }

        public IAction GetAction(string type)
        {
            return _handler[type]();
        }

        public void AddCommandContrainedAction<T>() where T : ICommand
        {
            var cmdType = typeof (T).ToString();

            if (_handler.ContainsKey(cmdType))
                throw new ArgumentException("Command type already added");

            _handler.Add(typeof (T).ToString(), () => new ActionCommandConstrainedOnly<T>());
        }

        //public void AddFullyConstrainedActionHandlerFor<T>() where T : ICommand
        //{
        //    var cmdType = typeof(T).ToString();

        //    if (_handler.ContainsKey(cmdType))
        //        throw new ArgumentException("Command type already added");

        //    _handler.Add(cmdType, (command) => new ActionContextuallyConstrained<T>((T)command, _commands, _committenti, _lotti, _tipiIntervento));
        //}

        
    }

    
}