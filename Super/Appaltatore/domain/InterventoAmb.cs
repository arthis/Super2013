using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging;
using CommonDomain.Core.Super.Messaging.Builders;
using Super.Appaltatore.Events;

using Super.Appaltatore.Events.Consuntivazione;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Domain
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

        public void ConsuntivareNonReso(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleAppaltatore, string note)
        {
           var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

           ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if(specs.IsSatisfiedBy(this))
            {
                var evt = BuildEvt.InterventoAmbConsuntivatoNonReso
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .Because(idCausaleAppaltatore)
                                .When(dataConsuntivazione)
                                .WithNote(note);

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoAmbConsuntivatoNonReso e)
        {
            //do something here if needed
        }

        public void ConsuntivareNonResoTrenitalia(Guid id, DateTime dataConsuntivazione, Guid idCausaleTrenitalia, string idInterventoAppaltatore, string note)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = BuildEvt.InterventoAmbConsuntivatoNonResoTrenitalia
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .Because(idCausaleTrenitalia)
                                .When(dataConsuntivazione)
                                .WithNote(note);

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoAmbConsuntivatoNonResoTrenitalia e)
        {
            //do something here if needed
        }

        public void ConsuntivareReso(Guid id, DateTime dataConsuntivazione, WorkPeriod workPeriod, string idInterventoAppaltatore, string note, string description, int quantity)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var periodBuilder = new MsgWorkPeriodBuilder();

                workPeriod.BuildValue(periodBuilder);

                var evt = BuildEvt.InterventoAmbConsuntivatoReso
                    .ForInterventoAppaltatore(idInterventoAppaltatore)
                    .When(dataConsuntivazione)
                    .WithNote(note)
                    .ForWorkPeriod(workPeriod.ToMessage())
                    .ForQuantity(quantity)
                    .ForDescription(description);

                RaiseEvent(evt);

            }
        }

        public void Apply(InterventoAmbConsuntivatoReso e)
        {
            //do something here if needed
        }
    }
}
