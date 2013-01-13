using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CommonDomain.Core.Handlers.Actions
{
    public class ActionCommandConstrainedOnly<T> : IAction  where T :ICommand
    {
        private readonly ICommand _command;
        private readonly IEnumerable<Regex> _commands;
        

        public ActionCommandConstrainedOnly(IEnumerable<Regex> commands)
        {
            _commands = commands;
        }
        
        public bool CanBeExecuted()
        {
            return _commands.Any(x=> x.IsMatch(_command.GetType().ToString()));
        }


    }
}