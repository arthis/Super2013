using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution;
using Commands.Interventi;
using Ncqrs.Domain;
using Domain.Interventi;

namespace ApplicationService.Executors
{
    public class ConsuntivareNonResoDaAppaltatoreExecutor : CommandExecutorBase<ConsuntivareRotabileNonResoDaAppaltatore>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, ConsuntivareRotabileNonResoDaAppaltatore command)
        {
            // Get the intervento
            var intervento = context.GetById<InterventoRotabile>(command.Id);

            // Perform The Consuntivazione
            intervento.ConsuntivaNonResoDaAppaltatore(command.InterventoIdAppaltatore,command.DataConsuntivazione);

            // Accept all the work we just did.
            context.Accept();
        }
    }
}
