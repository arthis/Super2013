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
                                , WorkPeriod workPeriod
                                , string note
                                , IEnumerable<OggettoRot> oggetti
                                ,Treno trenoArrivo
                                ,Treno trenoPartenza
                                , string turnoTreno
                                , string rigaTurnoTreno
                                , string convoglio
            )
        {


            var evt = BuildEvt.InterventoRotProgrammato
                            .WithOggetti(oggetti.ToMessage().ToArray())
                            .ForWorkPeriod(workPeriod.ToMessage())
                            .ForImpianto(idImpianto)
                            .OfTipoIntervento(idTipoIntervento)
                            .ForAppaltatore(idAppaltatore)
                            .ForCategoriaCommerciale(idCategoriaCommerciale)
                            .ForDirezioneRegionale(idDirezioneRegionale)
                            .WithNote(note)
                            .WithTrenoPartenza(trenoPartenza.ToMessage())
                            .WithTrenoArrivo(trenoArrivo.ToMessage())
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
                var evt = BuildEvt.InterventoRotConsuntivatoNonReso
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .Because(idCausaleAppaltatore)
                                .When(dataConsuntivazione)
                                .WithNote(note);

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoRotConsuntivatoNonReso e)
        {
            //do something here if needed
        }

        public void ConsuntivareNonResoTrenitalia(Guid id, DateTime dataConsuntivazione, Guid idCausaleTrenitalia, string idInterventoAppaltatore, string note)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = BuildEvt.InterventoRotConsuntivatoNonResoTrenitalia
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .Because(idCausaleTrenitalia)
                                .When(dataConsuntivazione)
                                .WithNote(note);

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoRotConsuntivatoNonResoTrenitalia e)
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

                var evt = BuildEvt.InterventoRotConsuntivatoReso       
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .When(dataConsuntivazione)
                                .WithNote(note)
                                .ForWorkPeriod(periodBuilder.Build())
                                .ForConvoglio(convoglio)
                                .WithTrenoPartenza(trenoPartenzaBuilder.Build())
                                .WithTrenoArrivo(trenoArrivoBuilder.Build())
                                .WithRigaTurnoTreno(rigaTurnoTreno)
                                .WithTurnoTreno(turnoTreno)
                                .WithOggetti(oggetti.ToMessage().ToArray());

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoRotConsuntivatoReso e)
        {
            //do something here if needed
        }
    }
}
