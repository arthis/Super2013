using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution;
using Commands;
using Ncqrs.Domain;
using Domain;
using Commands.TipoIntervento;
using System.Diagnostics.Contracts;
using Domain.TipoIntervento;

namespace Executors.TipoIntervento
{
    public class AggiornareTipoInterventoRotExecutor : CommandExecutorBase<AggiornareTipoInterventoRot>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, AggiornareTipoInterventoRot command)
        {
            Contract.Requires<ArgumentNullException>(command != null, "The command cannot be null.");
            Contract.Requires<ArgumentNullException>(context != null, "The context cannot be null.");

            // Get the object
            var tipo = context.GetById<TipoInterventoRot>(command.Id);

            // Perform The action
            tipo.Aggiornare(command.IdTipoInterventoSuper, command.Inizio, command.Fine, command.Descrizione);

            // Accept all the work we just did.
            context.Accept();
        }
    }

    public class AggiornareTipoInterventoRotManExecutor : CommandExecutorBase<AggiornareTipoInterventoRotMan>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, AggiornareTipoInterventoRotMan command)
        {
            Contract.Requires<ArgumentNullException>(command != null, "The command cannot be null.");
            Contract.Requires<ArgumentNullException>(context != null, "The context cannot be null.");

            // Get the object
            var tipo = context.GetById<TipoInterventoRotMan>(command.Id);

            // Perform The action
            tipo.Aggiornare(command.IdTipoInterventoSuper, command.Inizio, command.Fine, command.Descrizione);

            // Accept all the work we just did.
            context.Accept();
        }
    }

    public class AggiornareTipoInterventoAmbExecutor : CommandExecutorBase<AggiornareTipoInterventoAmb>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, AggiornareTipoInterventoAmb command)
        {
            Contract.Requires<ArgumentNullException>(command != null, "The command cannot be null.");
            Contract.Requires<ArgumentNullException>(context != null, "The context cannot be null.");

            // Get the object
            var tipo = context.GetById<TipoInterventoAmb>(command.Id);

            // Perform The action
            tipo.Aggiornare(command.IdTipoInterventoSuper, command.Inizio, command.Fine, command.Descrizione);

            // Accept all the work we just did.
            context.Accept();
        }
    }
}
