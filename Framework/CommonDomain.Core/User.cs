using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using CommonDomain.Core.Handlers.Actions;

namespace CommonDomain.Core
{

    public class SecurityUser : ISecurityUser
    {
        protected readonly Guid IdUser;
        private readonly IEnumerable<Regex> _commands;
        private readonly IEnumerable<Guid> _committenti;
        private readonly IEnumerable<Guid> _lotti;
        private readonly IEnumerable<Guid> _tipiIntervento;

        public SecurityUser(Guid idUser,IEnumerable<Regex> commands, IEnumerable<Guid> committenti, IEnumerable<Guid> lotti,IEnumerable<Guid> tipiIntervento )
        {
            Contract.Requires<ArgumentException>(idUser != Guid.Empty);
            Contract.Requires<ArgumentNullException>(commands != null);
            Contract.Requires<ArgumentNullException>(committenti != null);
            Contract.Requires<ArgumentNullException>(lotti != null);
            Contract.Requires<ArgumentNullException>(tipiIntervento != null);
            
            IdUser = idUser;
            _commands = commands;
            _committenti = committenti;
            _lotti = lotti;
            _tipiIntervento = tipiIntervento;
        }

        public IAction CreateAction<T>(IActionHandler handler, T cmd ) where T:ICommand
        {
            Contract.Requires<ArgumentNullException>(cmd != null);
            Contract.Requires<ArgumentNullException>(handler!=null);

            var factory = new ActionFactory(handler);
            return factory.WithCommands(_commands)
                .WithCommittenti(_committenti)
                .WithLotti(_lotti)
                .WithTipiIntervento(_tipiIntervento)
                .CreateAction(cmd);
        }

        
    }
}