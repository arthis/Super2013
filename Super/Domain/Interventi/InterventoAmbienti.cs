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
    public class InterventoAmbienti : Intervento
    {
        private int _TimeOutConsuntivazioneAppaltatore = 20;

        public int QuantitaScheduled { get; set; }
        public string DescrizioneScheduled { get; set; }

        public InterventoAmbienti()
        {
        }

        public InterventoAmbienti(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, int quantita, string descrizione)
            : base(id)
        {
            InterventoAmbientiCreato evt = new InterventoAmbientiCreato()
            {
                InterventoIdSuper = interventoIdSuper,
                IdAreaIntervento = idAreaIntervento,
                Inizio = inizio,
                Fine = fine,
                Quantita = quantita,
                Descrizione = descrizione
            };

            ApplyEvent(evt);
        }

 
        protected void OnInterventoCreato(InterventoAmbientiCreato e)
        {
            this.IdInterventoSuper = e.InterventoIdSuper;
            this.InizioScheduled = e.Inizio;
            this.FineScheduled = e.Fine;
            this.IdAreaIntervento = e.IdAreaIntervento;
        }


        public void ConsuntivaResoDaAppaltatore(string idInterventoAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine)
        {
            List<string> messagiValidazione = new List<string>();

            IsInterventoBeyondThe20MinutesSpecification IsInterventoBeyondThe20Minutes = new IsInterventoBeyondThe20MinutesSpecification(dataConsuntivazione, _TimeOutConsuntivazioneAppaltatore);
            IsInterventoSpuntatoSpecification IsInterventoSpuntato = new IsInterventoSpuntatoSpecification();

            ISpecification<Intervento> specs = IsInterventoBeyondThe20Minutes.And(IsInterventoSpuntato);

            if (specs.IsSatisfiedBy(this, messagiValidazione))
            {
                InterventoAmbientiConsuntivatoResoDaAppaltatore evt = new InterventoAmbientiConsuntivatoResoDaAppaltatore()
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

        public void OnInterventoAmbientiConsuntivatoResoDaAppaltatore(InterventoAmbientiConsuntivatoResoDaAppaltatore e)
        {
            this.StatoAppaltatore = new StatoAppaltatoreResoAmbienti()
            {
                DataConsuntivazione = e.DataConsuntivazione,
                idInterventoAppaltatore = e.IdInterventoAppaltatore,
                Inizio = e.Inizio,
                Fine = e.Fine
            };
        }

        public void ConsuntivaNonResoDaAppaltatore(string idInterventoAppaltatore, DateTime dataConsuntivazione)
        {
            List<string> messagiValidazione = new List<string>();

            IsInterventoBeyondThe20MinutesSpecification IsInterventoBeyondThe20Minutes = new IsInterventoBeyondThe20MinutesSpecification(dataConsuntivazione, _TimeOutConsuntivazioneAppaltatore);

            ISpecification<Intervento> specs = IsInterventoBeyondThe20Minutes;

            if (specs.IsSatisfiedBy(this, messagiValidazione))
            {
                InterventoAmbientiConsuntivatoNonResoDaAppaltatore evt = new InterventoAmbientiConsuntivatoNonResoDaAppaltatore()
                {
                    IdInterventoSuper = this.IdInterventoSuper,
                    DataConsuntivazione = dataConsuntivazione
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

        public void OnInterventoAmbientiConsuntivatoNonResoDaAppaltatore(InterventoAmbientiConsuntivatoNonResoDaAppaltatore e)
        {
            this.StatoAppaltatore = new StatoAppaltatoreNonResoAmbienti()
            {
                DataConsuntivazione = e.DataConsuntivazione,
                idInterventoAppaltatore = e.IdInterventoAppaltatore
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
                InterventoAmbientiConsuntivatoNonResoTrenitaliaDaAppaltatore evt = new InterventoAmbientiConsuntivatoNonResoTrenitaliaDaAppaltatore()
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

        public void OnInterventoAmbientiConsuntivatoNonResoTrenitaliaDaAppaltatore(InterventoAmbientiConsuntivatoNonResoTrenitaliaDaAppaltatore e)
        {
            this.StatoAppaltatore = new StatoAppaltatoreNonResoTrenitaliaAmbienti()
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
