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
    public class InterventoAmb : Intervento
    {
        private int _TimeOutConsuntivazioneAppaltatore = 20;

        public int QuantitaScheduled { get; set; }
        public string DescrizioneScheduled { get; set; }

        public InterventoAmb()
        {
        }

        public InterventoAmb(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, int quantita, string descrizione)
            : base(id)
        {
            InterventoAmbCreato evt = new InterventoAmbCreato()
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

 
        protected void OnInterventoCreato(InterventoAmbCreato e)
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
                InterventoAmbConsuntivatoResoDaAppaltatore evt = new InterventoAmbConsuntivatoResoDaAppaltatore()
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

        public void OnInterventoAmbConsuntivatoResoDaAppaltatore(InterventoAmbConsuntivatoResoDaAppaltatore e)
        {
            this.StatoAppaltatore = new StatoAppaltatoreResoAmb()
            {
                DataConsuntivazione = e.DataConsuntivazione,
                idInterventoAppaltatore = e.IdInterventoAppaltatore,
                Inizio = e.Inizio,
                Fine = e.Fine
            };
        }

        public void ConsuntivaNonResoDaAppaltatore(string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
        {
            List<string> messagiValidazione = new List<string>();

            IsInterventoBeyondThe20MinutesSpecification IsInterventoBeyondThe20Minutes = new IsInterventoBeyondThe20MinutesSpecification(dataConsuntivazione, _TimeOutConsuntivazioneAppaltatore);

            ISpecification<Intervento> specs = IsInterventoBeyondThe20Minutes;

            if (specs.IsSatisfiedBy(this, messagiValidazione))
            {
                InterventoAmbConsuntivatoNonResoDaAppaltatore evt = new InterventoAmbConsuntivatoNonResoDaAppaltatore()
                {
                    IdInterventoSuper = this.IdInterventoSuper,
                    DataConsuntivazione = dataConsuntivazione,
                    IdCausale = idCausale
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

        public void OnInterventoAmbConsuntivatoNonResoDaAppaltatore(InterventoAmbConsuntivatoNonResoDaAppaltatore e)
        {
            this.StatoAppaltatore = new StatoAppaltatoreNonResoAmb()
            {
                DataConsuntivazione = e.DataConsuntivazione,
                idInterventoAppaltatore = e.IdInterventoAppaltatore,
                IdCausale = e.IdCausale
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
                InterventoAmbConsuntivatoNonResoTrenitaliaDaAppaltatore evt = new InterventoAmbConsuntivatoNonResoTrenitaliaDaAppaltatore()
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

        public void OnInterventoAmbConsuntivatoNonResoTrenitaliaDaAppaltatore(InterventoAmbConsuntivatoNonResoTrenitaliaDaAppaltatore e)
        {
            this.StatoAppaltatore = new StatoAppaltatoreNonResoTrenitaliaAmb()
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
