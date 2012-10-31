using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace CommonDomain.Core
{
    public class SecurityUser : ISecurityUser
    {
        protected readonly Guid IdUser;
        private readonly IEnumerable<Type> _commands;
        private readonly IEnumerable<Guid> _committenti;
        private readonly IEnumerable<Guid> _lotti;
        private readonly IEnumerable<Guid> _tipiIntervento;

        public SecurityUser(Guid idUser,IEnumerable<Type> commands, IEnumerable<Guid> committenti, IEnumerable<Guid> lotti,IEnumerable<Guid> tipiIntervento )
        {
            Contract.Requires(idUser != Guid.Empty);
            Contract.Requires(commands != null);
            Contract.Requires(committenti != null);
            Contract.Requires(lotti != null);
            Contract.Requires(tipiIntervento != null);
            
            IdUser = idUser;
            _commands = commands;
            _committenti = committenti;
            _lotti = lotti;
            _tipiIntervento = tipiIntervento;
        }

        public IAction CreateAction(IActionFactory factory, ICommand cmd )
        {
            return factory.WithCommands(_commands)
                .WithCommittenti(_committenti)
                .WithLotti(_lotti)
                .WithTipiIntervento(_tipiIntervento)
                .CreateAction(cmd);
        }
    }
}