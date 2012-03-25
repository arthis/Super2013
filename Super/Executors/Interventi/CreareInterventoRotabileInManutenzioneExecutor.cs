using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution;
using Commands.Interventi;
using Ncqrs.Domain;
using Domain.Interventi;

namespace Executors
{
    public class CreareInterventoRotManExecutor : CommandExecutorBase<CreareInterventoPLGRotMan>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CreareInterventoPLGRotMan command)
        {
            // Perform The Consuntivazione
            InterventoRotMan i = new InterventoRotMan(command.Id, command.InterventoIdSuper, command.Inizio, command.Fine, command.IdAreaIntervento);
             
            // Accept all the work we just did.
            context.Accept();
        } 
    }
}
