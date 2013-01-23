using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text.RegularExpressions;
using CommonDomain.Super;

namespace CommonDomain.Core.Handlers.Actions
{
    public class ActionContextuallyConstrained<T> : IAction where T : ICommand
    {
        public IContextCommand CommandToBeExecuted { get; set; }
        public IEnumerable<Regex> CommandsAvailableToTheUser { get; set; }
        public IEnumerable<Guid> CommittentiAvailableToTheUser { get; set; }
        public IEnumerable<Guid> LottiAvailableToTheUser { get; set; }
        public IEnumerable<Guid> TipiInterventoAvailableToTheUser { get; set; }

        public ActionContextuallyConstrained( )
        {
        }


        public bool CanBeExecuted()
        {
            Contract.Requires<ArgumentNullException>(CommandToBeExecuted != null);
            Contract.Requires<ArgumentNullException>(CommandsAvailableToTheUser != null);
            Contract.Requires<ArgumentNullException>(CommittentiAvailableToTheUser != null);
            Contract.Requires<ArgumentNullException>(LottiAvailableToTheUser != null);
            Contract.Requires<ArgumentNullException>(TipiInterventoAvailableToTheUser != null);

            return CommandsAvailableToTheUser.Any(x => x.IsMatch(CommandToBeExecuted.GetType().ToString()))
                   && CommittentiAvailableToTheUser.Contains(CommandToBeExecuted.IdCommittente)
                   && LottiAvailableToTheUser.Contains(CommandToBeExecuted.IdLotto)
                   && TipiInterventoAvailableToTheUser.Contains(CommandToBeExecuted.IdTipoIntervento);
        }

        
    }
}
