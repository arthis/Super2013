using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution;
using Commands;
using Ncqrs.Domain;
using Domain;

namespace Executors.Interventi
{
    //public class ConsuntivareDaAppaltatoreExecutor : CommandExecutorBase<ConsuntivareDaAppaltatore>
    //{
    //    protected override void ExecuteInContext(IUnitOfWorkContext context, ConsuntivareDaAppaltatore command)
    //    {
    //        // Get the intervento
    //        var intervento = context.GetById<InterventoRot>(command.Id);

    //        // Perform The Consuntivazione
    //        intervento.ConsuntivaAppaltatore(command.InterventoIdAppaltatore, command.IsResoAppaltatore, command.Inizio, command.Fine);

    //        // Accept all the work we just did.
    //        context.Accept();
    //    }
    //}
}
