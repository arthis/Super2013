using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Commanding.CommandExecution;
using Commands;
using Cqrs.Domain;
using Domain;

namespace Executors.Interventi
{
    //public class ConsuntivareDaTrenitaliaExecutor : CommandExecutorBase<ConsuntivareDaTrenitalia>
    //{
    //    protected override void ExecuteInContext(IUnitOfWorkContext context, ConsuntivareDaTrenitalia command)
    //    {
    //        // Get the intervento
    //        var intervento = context.GetById<InterventoRot>(command.Id);

    //        // Perform The Consuntivazione
    //        intervento.ConsuntivaTrenitalia(command.IsResoTrenitalia, command.Inizio, command.Fine);

    //        // Accept all the work we just did.
    //        context.Accept();
    //    }
    //}
}
