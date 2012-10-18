using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using Super.Controllo.Events;

using Super.Controllo.Events.Consuntivazione;
using Super.Controllo.Events.Programmazione;

namespace Super.Controllo.Domain
{
    public class InterventoAmb : Intervento
    {

        public void Programmare(Guid id
                                , Guid idImpianto
                                , Guid idTipoIntervento
                                , Guid idAppaltatore
                                , Guid idCategoriaCommerciale
                                , Guid idDirezioneRegionale
                                , WorkPeriod workPeriod
                                , string note
                                , int quantity
                                , string description

            )
        {
            var evt = BuildEvt.InterventoAmbProgrammato
                            .ForWorkPeriod(workPeriod.ToMessage())
                            .ForImpianto(idImpianto)
                            .OfTipoIntervento(idTipoIntervento)
                            .ForAppaltatore(idAppaltatore)
                            .ForCategoriaCommerciale(idCategoriaCommerciale)
                            .ForDirezioneRegionale(idDirezioneRegionale)
                            .WithNote(note)
                            .ForQuantity(quantity)
                            .ForDescription((description));

            RaiseEvent(id, evt);
        }

        public void Apply(InterventoAmbProgrammato e)
        {
            Id = e.Id;
            //do something here if needed
        }

        public void ControlReso(Guid idUser, DateTime controlDate, WorkPeriod workPeriod, string note, int quantity, string description)
        {
         
            var evt = BuildEvt.InterventoAmbControlledReso
                .ForWorkPeriod(workPeriod.ToMessage())
                .By(idUser)
                .When(controlDate)
                .WithNote(note)
                .ForQuantity(quantity)
                .ForDescription(description);
            
            RaiseEvent(evt);
            
        }

        public void Apply(InterventoAmbControlledReso e)
        {
            //do nothing
        }

    }
}
