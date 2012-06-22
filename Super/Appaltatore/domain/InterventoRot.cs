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
    
    public class InterventoRot : Intervento
    {

        public void Programmare(Guid id
                                , Guid idAreaIntervento
                                , Guid idTipoIntervento
                                , Guid idAppaltatore
                                , Guid idCategoriaCommerciale
                                , Guid idDirezioneRegionale
                                , WorkPeriod period
                                , string note
                                , IEnumerable<OggettoRot> oggetti
                                ,Treno trenoArrivo
                                ,Treno trenoPartenza
                                , string turnoTreno
                                , string rigaTurnoTreno
                                , string convoglio
            )
        {

            //builders
            var builder = new InterventoRotProgrammatoBuilder();
            var periodBuilder = new WorkPeriodBuilder();
            var trenoPartenzaBuilder = new TrenoBuilder();
            var trenoArrivoBuilder = new TrenoBuilder();

            period.BuildValue(periodBuilder);
            trenoPartenza.BuildValue(trenoPartenzaBuilder);
            trenoArrivo.BuildValue(trenoArrivoBuilder);

            var evt = builder.WithOggetti(oggetti.ToMessage().ToArray())
                            .ForPeriod(periodBuilder.Build())
                            .ForId(id)
                            .In(idAreaIntervento)
                            .OfType(idTipoIntervento)
                            .ForAppaltatore(idAppaltatore)
                            .OfCategoriaCommerciale(idCategoriaCommerciale)
                            .OfDirezioneRegionale(idDirezioneRegionale)
                            .WithNote(note)
                            .WithTrenoPartenza(trenoPartenzaBuilder.Build())
                            .WithTrenoArrivo(trenoArrivoBuilder.Build())
                            .WithTurnoTreno(turnoTreno)
                            .WithRigaTurnoTreno(rigaTurnoTreno)
                            .ForConvoglio(convoglio)
                            .Build();
         
           RaiseEvent(evt);
       }

        public void Apply(InterventoRotProgrammato e)
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
                var builder = new InterventoConsuntivatoRotNonResoBuilder();

                var evt = builder.ForId(id)
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .Because(idCausaleAppaltatore)
                                .When(dataConsuntivazione)
                                .WithNote(note)
                                .Build();

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoConsuntivatoRotNonReso e)
        {
            //do something here if needed
        }

        public void ConsuntivareNonResoTrenitalia(Guid id, DateTime dataConsuntivazione, Guid idCausaleTrenitalia, string idInterventoAppaltatore, string note)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var builder = new InterventoConsuntivatoRotNonResoTrenitaliaBuilder();

                var evt = builder.ForId(id)
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .Because(idCausaleTrenitalia)
                                .When(dataConsuntivazione)
                                .WithNote(note)
                                .Build();

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoConsuntivatoRotNonResoTrenitalia e)
        {
            //do something here if needed
        }


       public void ConsuntivareReso(Guid id, DateTime dataConsuntivazione, WorkPeriod workPeriod,
           string idInterventoAppaltatore, string note, IEnumerable<OggettoRot> oggetti, string convoglio,
           Treno trenoPartenza,Treno trenoArrivo, string rigaTurnoTreno, string turnoTreno)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);
            

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var builder = new InterventoConsuntivatoRotResoBuilder();
                var periodBuilder = new WorkPeriodBuilder();
                var trenoPartenzaBuilder = new TrenoBuilder();
                var trenoArrivoBuilder = new TrenoBuilder();

                workPeriod.BuildValue(periodBuilder);
                trenoPartenza.BuildValue(trenoPartenzaBuilder);
                trenoArrivo.BuildValue(trenoArrivoBuilder);

                var evt = builder.ForId(id)
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .When(dataConsuntivazione)
                                .WithNote(note)
                                .ForPeriod(periodBuilder.Build())
                                .ForConvoglio(convoglio)
                                .WithTrenoPartenza(trenoPartenzaBuilder.Build())
                                .WithTrenoArrivo(trenoArrivoBuilder.Build())
                                .WithRigaTurnoTreno(rigaTurnoTreno)
                                .WithTurnoTreno(turnoTreno)
                                .WithOggetti(oggetti.ToMessage().ToArray())
                                .Build();

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoConsuntivatoRotReso e)
        {
            //do something here if needed
        }
    }
}
