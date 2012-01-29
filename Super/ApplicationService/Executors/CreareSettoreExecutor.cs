using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution;
using Commands;
using Ncqrs.Domain;
using Domain;

namespace ApplicationService.Executors
{
    public class CreareSettoreExecutor : CommandExecutorBase<CreareNuovoSettore>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CreareNuovoSettore command)
        {
            // Perform The creation
            Settore s = new Settore(command.Id, command.Mnemo, command.Descrizione);

            // Accept all the work we just did.
            context.Accept();
        }
    }
}
