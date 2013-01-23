using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using CommonDomain;
using CommonDomain.Super;

namespace CommonDomain.Core.Handlers.Actions
{
    public class ActionFactory : IActionFactory
    {
        private readonly IActionHandler _actionHandler;
        private IEnumerable<Regex> _commands;
        private IEnumerable<Guid> _committenti;
        private IEnumerable<Guid> _lotti;
        private IEnumerable<Guid> _tipiIntervento;
        

        public ActionFactory(IActionHandler actionHandler)
        {
            if (actionHandler == null) throw new ArgumentNullException("actionHandler");

            _actionHandler = actionHandler;
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
   
        public IAction CreateAction<T>(T command) where T : ICommand
        {
            var cmdType = typeof(T).ToString();
            if (_actionHandler.ContainsKey(cmdType))
            {
                var action = _actionHandler.GetAction(cmdType);
                new Switch(action)
                    .Case<ActionCommandConstrainedOnly<T>>(a => a.CommandsAvailableToTheUser = _commands)
                    .Case<ActionContextuallyConstrained<T>>(a =>
                        {
                            a.CommandToBeExecuted = (IContextCommand)command;
                            a.CommandsAvailableToTheUser = _commands;
                            a.LottiAvailableToTheUser = _lotti;
                            a.CommittentiAvailableToTheUser = _committenti;
                            a.TipiInterventoAvailableToTheUser = _tipiIntervento;
                        });
                return action;
            }
            

            throw  new ArgumentException("command not known");
        }
    }
}

