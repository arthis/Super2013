using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution;
using Commands.Interventi;
using Ncqrs.Domain;
using Domain.Interventi;

namespace Executors.Interventi
{
    public class CreareInterventoRotExecutor : CommandExecutorBase<CreareInterventoPLGRot>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CreareInterventoPLGRot command)
        {
            // Perform The Consuntivazione
            InterventoRot i = new InterventoRot(command.Id);

            i.CrearePlg(command.InterventoIdSuper, command.Inizio, command.Fine, command.IdAreaIntervento, command.IdTipoIntervento, command.DataCreazione, command.Oggetti.ToDomainOggettiRot());

            // Accept all the work we just did.
            context.Accept();
        }
    }

    public class CreareInterventoRotManExecutor : CommandExecutorBase<CreareInterventoPLGRotMan>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CreareInterventoPLGRotMan command)
        {
            // Perform The Consuntivazione
            InterventoRotMan i = new InterventoRotMan(command.Id);

            i.CrearePlg(command.InterventoIdSuper, command.Inizio, command.Fine, command.IdAreaIntervento, command.IdTipoIntervento, command.DataCreazione, command.Oggetti.ToDomainOggettiRotMan());

            // Accept all the work we just did.
            context.Accept();
        }
    }

    public class CreareInterventoAmbExecutor : CommandExecutorBase<CreareInterventoPLGAmb>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, CreareInterventoPLGAmb command)
        {
            // Perform The Consuntivazione
            InterventoAmb i = new InterventoAmb(command.Id);
            i.CrearePlg(command.InterventoIdSuper, command.Inizio, command.Fine, command.IdAreaIntervento, command.IdTipoIntervento, command.Quantita, command.Descrizione, command.DataCreazione);

            // Accept all the work we just did.
            context.Accept();
        }
    }
}
