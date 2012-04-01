using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Commanding.CommandExecution;
using Commands;
using Cqrs.Domain;
using Domain;
using Commands.AreaIntervento;
using System.Diagnostics.Contracts;

namespace Executors
{
    public class AggiornareAreaInterventoExecutor : CommandExecutorBase<AggiornareAreaIntervento>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, AggiornareAreaIntervento command)
        {
            Contract.Requires<ArgumentNullException>(command != null, "The command cannot be null.");
            Contract.Requires<ArgumentNullException>(context != null, "The context cannot be null.");

            // Get the object
            var area = context.GetById<AreaIntervento>(command.Id);

            // Perform The action
            area.Aggiornare(command.IdAreaInterventoSuper, command.Inizio, command.Fine, command.Descrizione);

            // Accept all the work we just did.
            context.Accept();
        }
    }
}
