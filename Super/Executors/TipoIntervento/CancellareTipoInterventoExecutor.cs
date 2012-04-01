using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Commanding.CommandExecution;
using Commands;
using Cqrs.Domain;
using Domain;
using Commands.TipoIntervento;
using Domain.TipoIntervento;

namespace Executors.TipoIntervento
{
    public class CancellareTipoInterventoRotExecutor : CommandExecutorBase<CancellareTipoInterventoRot>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CancellareTipoInterventoRot command)
        {
            // Get the item
            var tipo = context.GetById<TipoInterventoRot>(command.Id);

            // Perform The operation
            tipo.Cancellare();

            // Accept all the work we just did.
            context.Accept();
        }
    }

    public class CancellareTipoInterventoRotManExecutor : CommandExecutorBase<CancellareTipoInterventoRotMan>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CancellareTipoInterventoRotMan command)
        {
            // Get the item
            var tipo = context.GetById<TipoInterventoRotMan>(command.Id);

            // Perform The operation
            tipo.Cancellare();

            // Accept all the work we just did.
            context.Accept();
        }
    }

    public class CancellareTipoInterventoAmbExecutor : CommandExecutorBase<CancellareTipoInterventoAmb>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CancellareTipoInterventoAmb command)
        {
            // Get the item
            var tipo = context.GetById<TipoInterventoAmb>(command.Id);

            // Perform The operation
            tipo.Cancellare();

            // Accept all the work we just did.
            context.Accept();
        }
    }
}
