using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Commanding.CommandExecution;
using Commands;
using Cqrs.Domain;
using Domain;
using Commands.AreaIntervento;

namespace Executors
{
    public class CancellareAreaInterventoExecutor : CommandExecutorBase<CancellareAreaIntervento>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CancellareAreaIntervento command)
        {
            // Get the item
            var area = context.GetById<AreaIntervento>(command.Id);

            // Perform The operation
            area.Cancellare();

            // Accept all the work we just did.
            context.Accept();
        }
    }
}
