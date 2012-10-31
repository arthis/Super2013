using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace CommonDomain.Core.Handlers.Actions
{
    public class ActionFactory : IActionFactory
    {
        private IEnumerable<Type> _commands;
        private IEnumerable<Guid> _committenti;
        private IEnumerable<Guid> _lotti;
        private IEnumerable<Guid> _tipiIntervento;
        private Dictionary<Type,Func<IAction>> _handler;

        public ActionFactory()
        {
            _handler = new Dictionary<Type, Func<IAction>>();
        }

        public IActionFactory WithCommands(IEnumerable<Type> commands)
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

        public void AddFullyConstrainedAction<T>(T cmd) where T:ICommand
        {
            Type cmdType = typeof(T);

            if (_handler.ContainsKey(cmdType))
                throw  new ArgumentException("Command type already added");

            _handler.Add(cmdType, () => CreateFullyConstrainedAction(cmd));
        }

        public void AddCommandConstrainedOnlyAction<T>(T cmd) where T : ICommand
        {
            Type cmdType = typeof(T);

            if (_handler.ContainsKey(cmdType))
                throw new ArgumentException("Command type already added");

            _handler.Add(cmdType, () => CreateCommandConstrainedOnlyAction(cmd));
        }

        private IAction CreateFullyConstrainedAction(ICommand command)
        {
            Contract.Requires(command!=null);
            Contract.Requires(_commands!=null);
            Contract.Requires(_committenti != null);
            Contract.Requires(_lotti != null);
            Contract.Requires(_tipiIntervento != null);

            return new ActionFullyConstrained(command,  _commands,  _committenti,  _lotti, _tipiIntervento);
        }

        private IAction CreateCommandConstrainedOnlyAction(ICommand command)
        {
            Contract.Requires(command != null);
            Contract.Requires(_commands != null);

            return new ActionCommandConstrainedOnly(command,_commands);

        }

        public IAction CreateAction(ICommand cmd)
        {
            Type cmdType = cmd.GetType();
            if (_handler.ContainsKey(cmdType))
                return _handler[cmdType]();
             throw  new ArgumentException("command not known");
        }
    }
}