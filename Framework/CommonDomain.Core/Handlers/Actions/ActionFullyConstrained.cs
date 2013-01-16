using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CommonDomain.Core.Handlers.Actions
{
    public class ActionFullyConstrained<T> : IAction where T:ICommand
    {
        private readonly T _cmd;
        private readonly IEnumerable<Regex> _commands;
        private readonly IEnumerable<Guid> _committenti;
        private readonly IEnumerable<Guid> _lotti;
        private readonly IEnumerable<Guid> _tipiIntervento;

        public ActionFullyConstrained( T cmd , IEnumerable<Regex> commands, IEnumerable<Guid> committenti, IEnumerable<Guid> lotti, IEnumerable<Guid> tipiIntervento)
        {
            _cmd = cmd;
            _commands = commands;
            _committenti = committenti;
            _lotti = lotti;
            _tipiIntervento = tipiIntervento;
        }


        public bool CanBeExecuted()
        {
            return _commands.Any(x => x.IsMatch(_cmd.GetType().ToString()));
        }

        
    }
}
