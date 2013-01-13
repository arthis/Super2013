using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace CommonDomain.Core.Handlers.Actions
{
    public class ActionFactory : IActionFactory
    {
        private IEnumerable<Regex> _commands;
        private IEnumerable<Guid> _committenti;
        private IEnumerable<Guid> _lotti;
        private IEnumerable<Guid> _tipiIntervento;
        private Dictionary<string,Func<IAction>> _handler;

        public ActionFactory()
        {
            _handler = new Dictionary<string, Func<IAction>>();
        }

        public IActionFactory WithCommands(IEnumerable<Regex> commands)
        {
            _commands = commands;
            return this;
        }

        public IActionFactory WithCommittenti(IEnumerable<Guid> committenti)
        {
            _committenti = committenti;
            return this;
        }

        public IActionFactory WithLotti(IEnumerable<Guid> lotti)
        {
            _lotti = lotti;
            return this;
        }

        public IActionFactory WithTipiIntervento(IEnumerable<Guid> tipiIntervento)
        {
            _tipiIntervento = tipiIntervento;
            return this;
        }

        public void AddFullyConstrainedAction<T>() where T:ICommand
        {
            Contract.Requires(_commands != null);
            Contract.Requires(_committenti != null);
            Contract.Requires(_lotti != null);
            Contract.Requires(_tipiIntervento != null);

            var cmdType = typeof(T).ToString();

            if (_handler.ContainsKey(cmdType))
                throw  new ArgumentException("Command type already added");

            _handler.Add(cmdType, () => new ActionFullyConstrained<T>( _commands, _committenti, _lotti, _tipiIntervento));
        }

        public void AddCommandConstrainedOnlyAction<T>() where T:ICommand
        {
            Contract.Requires(_commands != null);

            var cmdType = typeof(T).ToString();

            if (_handler.ContainsKey(cmdType))
                throw new ArgumentException("Command type already added");

            _handler.Add(cmdType, () => new ActionCommandConstrainedOnly<T>(_commands));
        }

        
        public IAction CreateAction(ICommand cmd)
        {
            
            var cmdType = cmd.GetType().ToString();
            if (_handler.ContainsKey(cmdType))
                return _handler[cmdType]();
             throw  new ArgumentException("command not known");
        }
    }
}