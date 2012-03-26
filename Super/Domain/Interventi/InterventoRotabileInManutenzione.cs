using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Domain;
using Ncqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
using Events.Interventi;
using Domain.Interventi.Consuntivazione;



namespace Domain.Interventi
{
    [DynamicSnapshot]
    public class InterventoRotMan : Intervento
    {
        private int _TimeOutConsuntivazioneAppaltatore = 20;

        public IEnumerable<OggettoInterventoRotMan> OggettiScheduled { get; set; }


        public InterventoRotMan()
        {
        }

        public InterventoRotMan(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento)
            : base(id)
        {
            InterventoRotManCreato evt = new InterventoRotManCreato()
            {
                InterventoIdSuper = interventoIdSuper,
                IdAreaIntervento = idAreaIntervento,
                Inizio = inizio,
                Fine = fine
            };

            ApplyEvent(evt);
        }

        protected void OnInterventoCreato(InterventoRotManCreato e)
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
                InterventoRotManConsuntivatoResoDaAppaltatore evt = new InterventoRotManConsuntivatoResoDaAppaltatore()
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

        public void OnInterventoRotManConsuntivatoResoDaAppaltatore(InterventoRotManConsuntivatoResoDaAppaltatore e)
        {
            this.ConsuntivazioneAppaltatore = new ConsAppaltatoreResoRotMan()
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
                InterventoRotManConsuntivatoNonResoDaAppaltatore evt = new InterventoRotManConsuntivatoNonResoDaAppaltatore()
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

        public void OnInterventoRotManConsuntivatoNonResoDaAppaltatore(InterventoRotManConsuntivatoNonResoDaAppaltatore e)
        {
            this.ConsuntivazioneAppaltatore = new ConsAppaltatoreNonResoRotMan()
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
                InterventoRotManConsuntivatoNonResoTrenitaliaDaAppaltatore evt = new InterventoRotManConsuntivatoNonResoTrenitaliaDaAppaltatore()
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

        public void OnInterventoRotManConsuntivatoNonResoTrenitaliaDaAppaltatore(InterventoRotManConsuntivatoNonResoTrenitaliaDaAppaltatore e)
        {
            this.ConsuntivazioneAppaltatore = new ConsAppaltatoreNonResoTrenitaliaRotMan()
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
