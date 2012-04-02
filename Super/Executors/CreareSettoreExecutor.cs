using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Commanding.CommandExecution;
using Commands;
using Cqrs.Domain;
using Domain;

namespace Executors
{
    public class CreareSettoreExecutor : CommandExecutorBase<CreareNuovoSettore>
    {
        public CreareSettoreExecutor(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }

        protected override void ExecuteInContext(IUnitOfWorkContext context, CreareNuovoSettore command)
        {
            // Perform The creation
            Settore s = new Settore(command.Id, command.Mnemo, command.Descrizione);

            // Accept all the work we just did.
            context.Accept();
        }
    }
}
