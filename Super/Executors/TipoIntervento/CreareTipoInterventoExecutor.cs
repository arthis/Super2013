using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Commanding.CommandExecution;
using Commands;
using Cqrs.Domain;
using Commands.TipoIntervento;
using Domain;
using Domain.TipoIntervento;

namespace Executors.TipoIntervento
{
    public class CreareTipoInterventoRotExecutor : CommandExecutorBase<CreareTipoInterventoRot>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CreareTipoInterventoRot command)
        {
            // Perform The creation
            var ti = new TipoInterventoRot(command.Id, command.IdTipoInterventoSuper, command.Inizio, command.Fine, command.CreationDate, command.Descrizione);

            // Accept all the work we just did.
            context.Accept();
        }
    }

    public class CreareTipoInterventoRotManExecutor : CommandExecutorBase<CreareTipoInterventoRotMan>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CreareTipoInterventoRotMan command)
        {
            // Perform The creation
            var ti = new TipoInterventoRotMan(command.Id, command.IdTipoInterventoSuper, command.Inizio, command.Fine, command.CreationDate, command.Descrizione);

            // Accept all the work we just did.
            context.Accept();
        }
    }

    public class CreareTipoInterventoAmbExecutor : CommandExecutorBase<CreareTipoInterventoAmb>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CreareTipoInterventoAmb command)
        {
            // Perform The creation
            var ti = new TipoInterventoAmb(command.Id, command.IdTipoInterventoSuper, command.Inizio, command.Fine, command.CreationDate, command.Descrizione);

            // Accept all the work we just did.
            context.Accept();
        }
    }
}
