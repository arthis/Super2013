using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution;
using Commands.Interventi;
using Ncqrs.Domain;
using Domain.Interventi;

namespace Executors
{
    public class ConsuntivareResoDaAppaltatoreExecutor : CommandExecutorBase<ConsuntivareRotResoDaAppaltatore>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, ConsuntivareRotResoDaAppaltatore command)
        {
            // Get the intervento
            var intervento = context.GetById<InterventoRot>(command.Id);



            // Perform The Consuntivazione
            intervento.ConsuntivaResoDaAppaltatore(command.InterventoIdAppaltatore,
                                                    command.DataConsuntivazione,
                                                    command.Inizio,
                                                    command.Fine);
                                                    //,
                                                    //command.Oggetti.Select(x => new Domain.Interventi.OggettoInterventoRot()
                                                    //{
                                                    //    Descrizione = x.Descrizione,
                                                    //    Quantita = x.Quantita,
                                                    //    IdTipoOggettoInterventoRot = x.IdTipoOggettoInterventoRot
                                                    //}));

            // Accept all the work we just did.
            context.Accept();
        }
    }
}
