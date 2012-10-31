using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonDomain.Core.Handlers.Actions
{
    public class ActionCommandConstrainedOnly : IAction
    {
        private readonly ICommand _command;
        private readonly IEnumerable<Type> _commands;
        

        public ActionCommandConstrainedOnly(ICommand command, IEnumerable<Type> commands)
        {
            _command = command;
            _commands = commands;
        }


        public bool CanBeExecuted()
        {
            return _commands.Contains(_command.GetType());
        }


    }
}