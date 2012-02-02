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
    //public class CreareAreaInterventoExecutor : CommandExecutorBase<CreareNuovoAreaIntervento>
    //{
    //    protected override void ExecuteInContext(IUnitOfWorkContext context, CreareNuovoAreaIntervento command)
    //    {
    //        // Perform The creation
    //        AreaIntervento ai = new AreaIntervento(command.Id, command.IdAreaInterventoSuper, command.Inizio, command.Fine);

    //        // Accept all the work we just did.
    //        context.Accept();
    //    }
    //}
}
