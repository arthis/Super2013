using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Domain;
using Ncqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
using Events.Interventi;
using Domain.Interventi.Stati;


namespace Domain.Interventi
{
    [DynamicSnapshot]
    public class InterventoRotabile : Intervento
    {
        private int _TimeOutConsuntivazioneAppaltatore = 20;

        public IEnumerable<OggettoInterventoRotabile> OggettiScheduled { get; set; }


        public InterventoRotabile()
        {
        }

        public InterventoRotabile(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento)
            : base(id)
        {
            InterventoRotabileCreato evt = new InterventoRotabileCreato()
            {
                InterventoIdSuper = interventoIdSuper,
                IdAreaIntervento = idAreaIntervento,
                Inizio = inizio,
                Fine = fine
            };

            ApplyEvent(evt);
        }

        protected virtual void OnInterventoCreato(InterventoRotabileCreato e)
        {
            this.IdInterventoSuper = e.InterventoIdSuper;
            this.InizioScheduled = e.Inizio;
            this.FineScheduled = e.Fine;
            this.IdAreaIntervento = e.IdAreaIntervento;
        }

        public void ConsuntivaResoDaAppaltatore(string idInterventoAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, IEnumerable<OggettoIntervento> oggetti)
        {
            List<string> messagiValidazione = new List<string>();

            IsInterventoBeyondThe20MinutesSpecification IsInterventoBeyondThe20Minutes = new IsInterventoBeyondThe20MinutesSpecification(dataConsuntivazione, _TimeOutConsuntivazioneAppaltatore);
            IsInterventoSpuntatoSpecification IsInterventoSpuntato = new IsInterventoSpuntatoSpecification();

            ISpecification<Intervento> specs = IsInterventoBeyondThe20Minutes.And(IsInterventoSpuntato);

            if (specs.IsSatisfiedBy(this, messagiValidazione))
            {
                InterventoRotabileConsuntivatoResoDaAppaltatore evt = new InterventoRotabileConsuntivatoResoDaAppaltatore()
                {
                    IdInterventoSuper = this.IdInterventoSuper,
                    IdInterventoAppaltatore = idInterventoAppaltatore,
                    DataConsuntivazione = dataConsuntivazione,
                    Fine = fine,
                    Inizio = inizio
                };
                ApplyEvent(evt);
            }
            else
            {
                ConsuntivazioneResoDaAppaltatoreRejected evtCmdRejected = new ConsuntivazioneResoDaAppaltatoreRejected()
                {
                    Id = this.EventSourceId,
                    IdInterventoSuper = IdInterventoSuper,
                    IdInterventoAppaltatore = idInterventoAppaltatore,
                    Messaggio = messagiValidazione
                };
                ApplyEvent(evtCmdRejected);
            }
        }

        public void OnInterventoRotabileConsuntivatoResoDaAppaltatore(InterventoRotabileConsuntivatoResoDaAppaltatore e)
        {
            this.StatoAppaltatore = new StatoAppaltatoreResoRotabile()
            {
                DataConsuntivazione = e.DataConsuntivazione,
                idInterventoAppaltatore = e.IdInterventoAppaltatore,
                Inizio = e.Inizio,
                Fine = e.Fine
            };
        }

        public void ConsuntivaNonResoDaAppaltatore(string idInterventoAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine)
        {
            List<string> messagiValidazione = new List<string>();

            IsInterventoBeyondThe20MinutesSpecification IsInterventoBeyondThe20Minutes = new IsInterventoBeyondThe20MinutesSpecification(dataConsuntivazione, _TimeOutConsuntivazioneAppaltatore);

            ISpecification<Intervento> specs = IsInterventoBeyondThe20Minutes;

            if (specs.IsSatisfiedBy(this, messagiValidazione))
            {
                InterventoRotabileConsuntivatoNonResoDaAppaltatore evt = new InterventoRotabileConsuntivatoNonResoDaAppaltatore()
                {
                    IdInterventoSuper = this.IdInterventoSuper,
                    DataConsuntivazione = dataConsuntivazione,
                    Fine = fine,
                    Inizio = inizio
                };
                ApplyEvent(evt);
            }
            else
            {
                ConsuntivazioneResoDaAppaltatoreRejected evtCmdRejected = new ConsuntivazioneResoDaAppaltatoreRejected()
                {
                    Id = this.EventSourceId,
                    IdInterventoSuper = IdInterventoSuper,
                    IdInterventoAppaltatore = idInterventoAppaltatore,
                    Messaggio = messagiValidazione
                };
                ApplyEvent(evtCmdRejected);
            }
        }

        public void OnInterventoRotabileConsuntivatoNonResoDaAppaltatore(InterventoRotabileConsuntivatoNonResoDaAppaltatore e)
        {
            this.StatoAppaltatore = new StatoAppaltatoreNonResoRotabile()
            {
                DataConsuntivazione = e.DataConsuntivazione,
                idInterventoAppaltatore = e.IdInterventoAppaltatore,
                Inizio = e.Inizio,
                Fine = e.Fine
            };

        }

        public void ConsuntivaNonResoTrenitaliaDaAppaltatore(string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid IdCausale)
        {
            List<string> messagiValidazione = new List<string>();

            IsInterventoBeyondThe20MinutesSpecification IsInterventoBeyondThe20Minutes = new IsInterventoBeyondThe20MinutesSpecification(dataConsuntivazione, _TimeOutConsuntivazioneAppaltatore);
            IsInterventoSpuntatoSpecification IsInterventoSpuntato = new IsInterventoSpuntatoSpecification();

            ISpecification<Intervento> specs = IsInterventoBeyondThe20Minutes.And(IsInterventoSpuntato);

            if (specs.IsSatisfiedBy(this, messagiValidazione))
            {
                InterventoRotabileConsuntivatoNonResoTrenitaliaDaAppaltatore evt = new InterventoRotabileConsuntivatoNonResoTrenitaliaDaAppaltatore()
                {
                    IdInterventoSuper = this.IdInterventoSuper,
                    IdInterventoAppaltatore = IdInterventoAppaltatore,
                    DataConsuntivazione = dataConsuntivazione,
                    IdCausale = IdCausale

                };
                ApplyEvent(evt);
            }
            else
            {
                ConsuntivazioneResoDaAppaltatoreRejected evtCmdRejected = new ConsuntivazioneResoDaAppaltatoreRejected()
                {
                    Id = this.EventSourceId,
                    IdInterventoSuper = IdInterventoSuper,
                    IdInterventoAppaltatore = idInterventoAppaltatore,
                    Messaggio = messagiValidazione
                };
                ApplyEvent(evtCmdRejected);
            }
        }

        public void OnInterventoRotabileConsuntivatoNonResoTrenitaliaDaAppaltatore(InterventoRotabileConsuntivatoNonResoTrenitaliaDaAppaltatore e)
        {
            this.StatoAppaltatore = new StatoAppaltatoreNonResoTrenitaliaRotabile()
            {
                idInterventoAppaltatore = e.IdInterventoAppaltatore,
                DataConsuntivazione = e.DataConsuntivazione,
                IdCausale = e.IdCausale
            };
        }


        public override int GetTimeOutConsuntivazioneAppaltatore()
        {
            return _TimeOutConsuntivazioneAppaltatore;
        }

    }
}
