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
    public class InterventoRot : Intervento
    {
        private int _TimeOutConsuntivazioneAppaltatore = 20;

        public IEnumerable<OggettoInterventoRot> OggettiScheduled { get; set; }


        public InterventoRot()
        {
        }

        public InterventoRot(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento)
            : base(id)
        {
            InterventoRotCreato evt = new InterventoRotCreato()
            {
                InterventoIdSuper = interventoIdSuper,
                IdAreaIntervento = idAreaIntervento,
                Inizio = inizio,
                Fine = fine
            };

            ApplyEvent(evt);
        }

        protected virtual void OnInterventoCreato(InterventoRotCreato e)
        {
            this.IdInterventoSuper = e.InterventoIdSuper;
            this.InizioScheduled = e.Inizio;
            this.FineScheduled = e.Fine;
            this.IdAreaIntervento = e.IdAreaIntervento;
        }

        public void ConsuntivaResoDaAppaltatore(string idInterventoAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine)//, IEnumerable<OggettoIntervento> oggetti)
        {
            List<string> messagiValidazione = new List<string>();

            IsInterventoBeyondThe20MinutesSpecification IsInterventoBeyondThe20Minutes = new IsInterventoBeyondThe20MinutesSpecification(dataConsuntivazione, _TimeOutConsuntivazioneAppaltatore);
            IsInterventoSpuntatoSpecification IsInterventoSpuntato = new IsInterventoSpuntatoSpecification();

            ISpecification<Intervento> specs = IsInterventoBeyondThe20Minutes.And(IsInterventoSpuntato);

            if (specs.IsSatisfiedBy(this, messagiValidazione))
            {
                InterventoRotConsuntivatoResoDaAppaltatore evt = new InterventoRotConsuntivatoResoDaAppaltatore()
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

        public void OnInterventoRotConsuntivatoResoDaAppaltatore(InterventoRotConsuntivatoResoDaAppaltatore e)
        {
            this.StatoAppaltatore = new StatoAppaltatoreResoRot()
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
                InterventoRotConsuntivatoNonResoDaAppaltatore evt = new InterventoRotConsuntivatoNonResoDaAppaltatore()
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

        public void OnInterventoRotConsuntivatoNonResoDaAppaltatore(InterventoRotConsuntivatoNonResoDaAppaltatore e)
        {
            this.StatoAppaltatore = new StatoAppaltatoreNonResoRot()
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
                InterventoRotConsuntivatoNonResoTrenitaliaDaAppaltatore evt = new InterventoRotConsuntivatoNonResoTrenitaliaDaAppaltatore()
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

        public void OnInterventoRotConsuntivatoNonResoTrenitaliaDaAppaltatore(InterventoRotConsuntivatoNonResoTrenitaliaDaAppaltatore e)
        {
            this.StatoAppaltatore = new StatoAppaltatoreNonResoTrenitaliaRot()
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
