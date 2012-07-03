using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using Super.Appaltatore.Events.Builders;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Domain
{
    
    public class InterventoRotMan : Intervento
    {

        public void Programmare(Guid id
                                        , Guid idImpianto
                                        , Guid idTipoIntervento
                                        , Guid idAppaltatore
                                        , Guid idCategoriaCommerciale
                                        , Guid idDirezioneRegionale
                                        , WorkPeriod workPeriod
                                        , string note
                                        , IEnumerable<OggettoRotMan> oggetti
                    )
        {
            //builders
            var periodBuilder = new WorkPeriodBuilder();

            workPeriod.BuildValue(periodBuilder);

            var evt = Build.InterventoRotManProgrammato
                            .WithOggetti(oggetti.ToMessage().ToArray())
                            .ForPeriod(periodBuilder.Build())
                            .ForImpianto(idImpianto)
                            .OfType(idTipoIntervento)
                            .ForAppaltatore(idAppaltatore)
                            .OfCategoriaCommerciale(idCategoriaCommerciale)
                            .OfDirezioneRegionale(idDirezioneRegionale)
                            .WithNote(note);

            RaiseEvent(id, evt);
        }

        public void Apply(InterventoRotManProgrammato e)
        {
            Id = e.Id;
            //do something here if needed
        }


        public void ConsuntivareNonReso(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleAppaltatore, string note)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.InterventoConsuntivatoRotManNonReso
                    .ForInterventoAppaltatore(idInterventoAppaltatore)
                    .Because(idCausaleAppaltatore)
                    .When(dataConsuntivazione)
                    .WithNote(note);

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoConsuntivatoRotManNonReso e)
        {
            //do something here if needed
        }


        public void ConsuntivareNonResoTrenitalia(Guid id, DateTime dataConsuntivazione, Guid idCausaleTrenitalia, string idInterventoAppaltatore, string note)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.InterventoConsuntivatoRotManNonResoTrenitalia
                    .ForInterventoAppaltatore(idInterventoAppaltatore)
                    .Because(idCausaleTrenitalia)
                    .When(dataConsuntivazione)
                    .WithNote(note);

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoConsuntivatoRotManNonResoTrenitalia e)
        {
            //do something here if needed
        }

        public void ConsuntivareReso(Guid id, DateTime dataConsuntivazione, WorkPeriod workPeriod, string idInterventoAppaltatore, string note, IEnumerable<OggettoRotMan> oggetti)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var periodBuilder = new WorkPeriodBuilder();

                workPeriod.BuildValue(periodBuilder);

                var evt = Build.InterventoConsuntivatoRotManReso
                    .ForInterventoAppaltatore(idInterventoAppaltatore)
                    .When(dataConsuntivazione)
                    .WithNote(note)
                    .ForPeriod(periodBuilder.Build())
                    .WithOggetti(oggetti.ToMessage().ToArray());

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoConsuntivatoRotManReso e)
        {
            //do something here if needed
        }
    }
}
