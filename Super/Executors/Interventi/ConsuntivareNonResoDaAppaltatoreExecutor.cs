using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Commanding.CommandExecution;
using Commands.Interventi;
using Cqrs.Domain;
using Domain.Interventi;

namespace Executors.Interventi
{
    public class ConsuntivareNonResoDaAppaltatoreExecutor : CommandExecutorBase<ConsuntivareRotNonResoDaAppaltatore>
    {
        public ConsuntivareNonResoDaAppaltatoreExecutor(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }

        protected override void ExecuteInContext(IUnitOfWorkContext context, ConsuntivareRotNonResoDaAppaltatore command)
        {
            // Get the intervento
            var intervento = context.GetById<InterventoRot>(command.Id);

            // Perform The Consuntivazione
            intervento.ConsuntivaNonResoDaAppaltatore(command.InterventoIdAppaltatore,command.DataConsuntivazione,  command.IdCausale);

            // Accept all the work we just did.
            context.Accept();
        }
    }
}
