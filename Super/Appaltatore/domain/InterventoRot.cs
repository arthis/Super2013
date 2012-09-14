using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using Super.Appaltatore.Events;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Domain
{
    
    public class InterventoRot : Intervento
    {

        public void Programmare(Guid id
                                , Guid idImpianto
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
            var periodBuilder = new MsgWorkPeriodBuilder();
            var trenoPartenzaBuilder = new MsgTrenoBuilder();
            var trenoArrivoBuilder = new MsgTrenoBuilder();

            period.BuildValue(periodBuilder);
            trenoPartenza.BuildValue(trenoPartenzaBuilder);
            trenoArrivo.BuildValue(trenoArrivoBuilder);

            var evt = BuildEvt.InterventoRotProgrammato
                            .WithOggetti(oggetti.ToMessage().ToArray())
                            .ForPeriod(periodBuilder.Build())
                            .ForImpianto(idImpianto)
                            .OfType(idTipoIntervento)
                            .ForAppaltatore(idAppaltatore)
                            .OfCategoriaCommerciale(idCategoriaCommerciale)
                            .OfDirezioneRegionale(idDirezioneRegionale)
                            .WithNote(note)
                            .WithTrenoPartenza(trenoPartenzaBuilder.Build())
                            .WithTrenoArrivo(trenoArrivoBuilder.Build())
                            .WithTurnoTreno(turnoTreno)
                            .WithRigaTurnoTreno(rigaTurnoTreno)
                            .ForConvoglio(convoglio);

            RaiseEvent(id, evt);
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
                var evt = BuildEvt.InterventoConsuntivatoRotNonReso
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .Because(idCausaleAppaltatore)
                                .When(dataConsuntivazione)
                                .WithNote(note);

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
                var evt = BuildEvt.InterventoConsuntivatoRotNonResoTrenitalia
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .Because(idCausaleTrenitalia)
                                .When(dataConsuntivazione)
                                .WithNote(note);

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
                var periodBuilder = new MsgWorkPeriodBuilder();
                var trenoPartenzaBuilder = new MsgTrenoBuilder();
                var trenoArrivoBuilder = new MsgTrenoBuilder();

                workPeriod.BuildValue(periodBuilder);
                trenoPartenza.BuildValue(trenoPartenzaBuilder);
                trenoArrivo.BuildValue(trenoArrivoBuilder);

                var evt = BuildEvt.InterventoConsuntivatoRotReso       
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .When(dataConsuntivazione)
                                .WithNote(note)
                                .ForPeriod(periodBuilder.Build())
                                .ForConvoglio(convoglio)
                                .WithTrenoPartenza(trenoPartenzaBuilder.Build())
                                .WithTrenoArrivo(trenoArrivoBuilder.Build())
                                .WithRigaTurnoTreno(rigaTurnoTreno)
                                .WithTurnoTreno(turnoTreno)
                                .WithOggetti(oggetti.ToMessage().ToArray());

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoConsuntivatoRotReso e)
        {
            //do something here if needed
        }
    }
}
