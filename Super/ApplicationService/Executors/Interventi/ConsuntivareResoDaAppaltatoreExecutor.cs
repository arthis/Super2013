using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution;
using Commands.Interventi;
using Ncqrs.Domain;
using Domain.Interventi;

namespace ApplicationService.Executors
{
    public class ConsuntivareResoDaAppaltatoreExecutor : CommandExecutorBase<ConsuntivareRotabileResoDaAppaltatore>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, ConsuntivareRotabileResoDaAppaltatore command)
        {
            // Get the intervento
            var intervento = context.GetById<InterventoRotabile>(command.Id);



            // Perform The Consuntivazione
            intervento.ConsuntivaResoDaAppaltatore(command.InterventoIdAppaltatore,
                                                    command.DataConsuntivazione,
                                                    command.Inizio,
                                                    command.Fine);
                                                    //,
                                                    //command.Oggetti.Select(x => new Domain.Interventi.OggettoInterventoRotabile()
                                                    //{
                                                    //    Descrizione = x.Descrizione,
                                                    //    Quantita = x.Quantita,
                                                    //    IdTipoOggettoInterventoRotabile = x.IdTipoOggettoInterventoRotabile
                                                    //}));

            // Accept all the work we just did.
            context.Accept();
        }
    }
}
