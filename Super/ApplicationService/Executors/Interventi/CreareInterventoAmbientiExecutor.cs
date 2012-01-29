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
    public class CreareInterventoAmbientiExecutor : CommandExecutorBase<CreareNuovoInterventoAmbienti>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CreareNuovoInterventoAmbienti command)
        {
            // Perform The Consuntivazione
            InterventoAmbienti i = new InterventoAmbienti(command.Id, command.InterventoIdSuper, command.Inizio, command.Fine, command.IdAreaIntervento, command.Quantita, command.Descrizione);
             
            // Accept all the work we just did.
            context.Accept();
        } 
    }
}
