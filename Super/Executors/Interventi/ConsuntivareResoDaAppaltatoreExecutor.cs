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
    public class ConsuntivareRotResoDaAppaltatoreExecutor : CommandExecutorBase<ConsuntivareRotResoDaAppaltatore>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, ConsuntivareRotResoDaAppaltatore command)
        {
            // Get the intervento
            var intervento = context.GetById<InterventoRot>(command.Id);



            // Perform The Consuntivazione
            intervento.ConsuntivaResoDaAppaltatore( command.InterventoIdAppaltatore,
                                                    command.DataConsuntivazione,
                                                    command.Inizio,
                                                    command.Fine,
                                                    command.Oggetti.Select(x => new Domain.Interventi.OggettoInterventoRot()
                                                    {
                                                        Descrizione = x.Descrizione,
                                                        Quantita = x.Quantita,
                                                        IdTipoOggettoInterventoRot = x.IdTipoOggettoInterventoRot
                                                    }));

            // Accept all the work we just did.
            context.Accept();
        }
    }

    public class ConsuntivareRotManResoDaAppaltatoreExecutor : CommandExecutorBase<ConsuntivareRotManResoDaAppaltatore>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, ConsuntivareRotManResoDaAppaltatore command)
        {
            // Get the intervento
            var intervento = context.GetById<InterventoRotMan>(command.Id);



            // Perform The Consuntivazione
            intervento.ConsuntivaResoDaAppaltatore(command.InterventoIdAppaltatore,
                                                    command.DataConsuntivazione,
                                                    command.Inizio,
                                                    command.Fine,
                                                    command.Oggetti.Select(x => new Domain.Interventi.OggettoInterventoRotMan()
                                                    {
                                                        Descrizione = x.Descrizione,
                                                        Quantita = x.Quantita,
                                                        IdTipoOggettoInterventoRotMan = x.IdTipoOggettoInterventoRotMan
                                                    }));

            // Accept all the work we just did.
            context.Accept();
        }
    }

    public class ConsuntivareAmbResoDaAppaltatoreExecutor : CommandExecutorBase<ConsuntivareAmbResoDaAppaltatore>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, ConsuntivareAmbResoDaAppaltatore command)
        {
            // Get the intervento
            var intervento = context.GetById<InterventoAmb>(command.Id);



            // Perform The Consuntivazione
            intervento.ConsuntivaResoDaAppaltatore(command.InterventoIdAppaltatore,
                                                    command.DataConsuntivazione,
                                                    command.Inizio,
                                                    command.Fine);

            // Accept all the work we just did.
            context.Accept();
        }
    }
}
