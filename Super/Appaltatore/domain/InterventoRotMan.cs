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
                                        , Guid idCommittente
                                        , Guid idPeriodoProgrammazione
                                        , Guid idProgramma
                                        , Guid idLotto
                    )
        {

            var evt = BuildEvt.InterventoRotManProgrammato
                .WithOggetti(oggetti.ToMessage().ToArray())
                .ForWorkPeriod(workPeriod.ToMessage())
                .ForImpianto(idImpianto)
                .OfTipoIntervento(idTipoIntervento)
                .ForAppaltatore(idAppaltatore)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .WithNote(note)
                .ForProgramma(idProgramma)
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForCommittente(idCommittente)
                .ForLotto(idLotto);

            RaiseEvent(id, evt);
        }

        public void Apply(InterventoRotManProgrammato e)
        {
            Id = e.Id;
            ProgrammedWorkPeriod = e.WorkPeriod.ToDomain();
            //do something here if needed
        }


        public void ConsuntivareNonReso(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleAppaltatore, string note)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = BuildEvt.InterventoRotManConsuntivatoNonReso
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .Because(idCausaleAppaltatore)
                                .When(dataConsuntivazione)
                                .WithNote(note);

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoRotManConsuntivatoNonReso e)
        {
            //do something here if needed
        }

        public void ConsuntivareNonResoTrenitalia(Guid id, DateTime dataConsuntivazione, Guid idCausaleTrenitalia, string idInterventoAppaltatore, string note)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = BuildEvt.InterventoRotManConsuntivatoNonResoTrenitalia
                                .ForInterventoAppaltatore(idInterventoAppaltatore)
                                .Because(idCausaleTrenitalia)
                                .When(dataConsuntivazione)
                                .WithNote(note);

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoRotManConsuntivatoNonResoTrenitalia e)
        {
            //do something here if needed
        }


        public void ConsuntivareReso(Guid id, DateTime dataConsuntivazione, WorkPeriod workPeriod, string idInterventoAppaltatore, string note, IEnumerable<OggettoRotMan> oggetti)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);
            var has_workPeriod_contained_in_workperiod_programmata =
                 new Has_workPeriod_contained_in_workperiod_programmata(workPeriod);


            ISpecification<Intervento> specs = is_data_consuntivazione_valid
                                                 .And(has_workPeriod_contained_in_workperiod_programmata);

            if (specs.IsSatisfiedBy(this))
            {
                var evt = BuildEvt.InterventoRotManConsuntivatoReso
                    .ForInterventoAppaltatore(idInterventoAppaltatore)
                    .When(dataConsuntivazione)
                    .WithNote(note)
                    .ForWorkPeriod(workPeriod.ToMessage())
                    .WithOggetti(oggetti.ToMessage().ToArray());

                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoRotManConsuntivatoReso e)
        {
            //do something here if needed
        }
    }
}
