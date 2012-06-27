using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using Super.Appaltatore.Events.Builders;
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

            //builders
            var periodBuilder = new WorkPeriodBuilder();

            workPeriod.BuildValue(periodBuilder);

            var evt = Build.InterventoAmbProgrammato
                            .ForPeriod(periodBuilder.Build())
                            .ForId(id)
                            .ForArea(idImpianto)
                            .OfType(idTipoIntervento)
                            .ForAppaltatore(idAppaltatore)
                            .OfCategoriaCommerciale(idCategoriaCommerciale)
                            .OfDirezioneRegionale(idDirezioneRegionale)
                            .WithNote(note)
                            .WithQuantity(quantity)
                            .WithDescription((description))
                            .Build();

            RaiseEvent(evt);
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
                var evt = Build.InterventoConsuntivatoAmbNonReso
                                .ForId(id)
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .Because(idCausaleAppaltatore)
                                .When(dataConsuntivazione)
                                .WithNote(note)
                                .Build();

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoConsuntivatoAmbNonReso e)
        {
            //do something here if needed
        }

        public void ConsuntivareNonResoTrenitalia(Guid id, DateTime dataConsuntivazione, Guid idCausaleTrenitalia, string idInterventoAppaltatore, string note)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.InterventoConsuntivatoAmbNonResoTrenitalia
                                .ForId(id)
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .Because(idCausaleTrenitalia)
                                .When(dataConsuntivazione)
                                .WithNote(note)
                                .Build();

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoConsuntivatoAmbNonResoTrenitalia e)
        {
            //do something here if needed
        }

        public void ConsuntivareReso(Guid id, DateTime dataConsuntivazione, WorkPeriod workPeriod, string idInterventoAppaltatore, string note, string description, int quantity)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var periodBuilder = new WorkPeriodBuilder();

                workPeriod.BuildValue(periodBuilder);

                var evt = Build.InterventoConsuntivatoAmbReso
                                .ForId(id)
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .When(dataConsuntivazione)
                                .WithNote(note)
                                .ForPeriod(periodBuilder.Build())
                                .ForQuantity(quantity)
                                .ForDescription(description)
                                .Build();

                RaiseEvent(evt);

            }
        }

        public void Apply(InterventoConsuntivatoAmbReso e)
        {
            //do something here if needed
        }
    }
}
