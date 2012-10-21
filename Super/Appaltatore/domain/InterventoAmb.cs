using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
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
                                , Guid idCommittente
                                , Guid idPeriodoProgrammazione
                                , Guid idProgramma
                                , Guid idLotto
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
                .ForDescription((description))
                .ForProgramma(idProgramma)
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForCommittente(idCommittente)
                .ForLotto(idLotto);

            RaiseEvent(id, evt);
        }

        public void Apply(InterventoAmbProgrammato e)
        {
            Id = e.Id;
            ProgrammedWorkPeriod = e.WorkPeriod.ToDomain();
        }

        public void ConsuntivareNonReso(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleAppaltatore, string note)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);
            
            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
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
            StatoAppaltatore= E_StatoAppaltatore.NonReso;
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
            StatoAppaltatore = E_StatoAppaltatore.NonResoTrenitalia;
        }

        public void ConsuntivareReso(Guid id, DateTime dataConsuntivazione, WorkPeriod workPeriod, string idInterventoAppaltatore, string note, string description, int quantity)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);
            var has_workPeriod_contained_in_workperiod_programmata =
                new Has_workPeriod_contained_in_workperiod_programmata(workPeriod);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid
                                                .And(has_workPeriod_contained_in_workperiod_programmata);

            if (specs.IsSatisfiedBy(this))
            {
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
            StatoAppaltatore = E_StatoAppaltatore.Reso;
        }

        public void ConsuntivareAutomaticamenteNonReso(DateTime dataConsuntivazione)
        {
            var has_Intervento_been_Consuntivated = new Has_Intervento_been_Consuntivated();

            var specs = has_Intervento_been_Consuntivated;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = BuildEvt.InterventoAmbConsuntivatoNonReso
                                .ForInterventoAppaltatore(IdInterventoAppaltatoreAutomatica)
                                .Because(IdCausaleAppaltatoreAutomatica)
                                .When(dataConsuntivazione)
                                .WithNote(string.Empty);

                RaiseEvent(evt);
            }
        }
    }
}
