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
    public class CreareCausaleExecutor : CommandExecutorBase<CreareNuovaCausale>
    {
        public CreareCausaleExecutor(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }

        protected override void ExecuteInContext(IUnitOfWorkContext context, CreareNuovaCausale command)
        {
            // Perform The creation
            Causale c = new Causale(command.Id,command.Tipo, command.Mnemo, command.Descrizione, command.IdSettoreIntervento);

            // Accept all the work we just did.
            context.Accept();
        }
    }
}
