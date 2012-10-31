using System;
using System.Collections.Generic;

namespace CommonDomain.Core.Handlers.Actions
{
    public class ActionFullyConstrained : IAction
    {
        private readonly ICommand _command;
        private readonly IEnumerable<Type> _commands;
        private readonly IEnumerable<Guid> _committenti;
        private readonly IEnumerable<Guid> _lotti;
        private readonly IEnumerable<Guid> _tipiIntervento;

        public ActionFullyConstrained(ICommand command, IEnumerable<Type> commands, IEnumerable<Guid> committenti, IEnumerable<Guid> lotti, IEnumerable<Guid> tipiIntervento)
        {
            _command = command;
            _commands = commands;
            _committenti = committenti;
            _lotti = lotti;
            _tipiIntervento = tipiIntervento;
        }


        public bool CanBeExecuted()
        {
            throw new NotImplementedException();
        }

        
    }
}
