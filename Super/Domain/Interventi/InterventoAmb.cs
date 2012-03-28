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
    public class InterventoAmb : Intervento
    {
        private int _ScadenzaConsuntivazioneAppaltatore = 20;

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

            IsInterventoBeyondTheScadenzaSpecification isInterventoBeyondTheScadenza = new IsInterventoBeyondTheScadenzaSpecification(dataConsuntivazione, _ScadenzaConsuntivazioneAppaltatore);
            IsInterventoSpuntatoSpecification isInterventoSpuntato = new IsInterventoSpuntatoSpecification();
            IsInterventoInibitoSpecification isInterventoInibitoSpecification = new IsInterventoInibitoSpecification();

            ISpecification<Intervento> specs = isInterventoBeyondTheScadenza.And(isInterventoSpuntato);

            if (specs.IsSatisfiedBy(this, messagiValidazione))
            {
                var evt = new ConsAppaltatoreAmbResoCreato()
                {
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

        public void OnConsAppaltatoreAmbResoCreato(ConsAppaltatoreAmbResoCreato e)
        {
            var consuntivo = new ConsAppaltatoreAmbReso(e.DataConsuntivazione,
                                                        e.IdInterventoAppaltatore,
                                                        e.Inizio,
                                                        e.Fine);
            ConsuntivazioneAppaltatore = consuntivo;
        }

        public void ConsuntivaNonResoDaAppaltatore(string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
        {
            List<string> messagiValidazione = new List<string>();

            IsInterventoBeyondTheScadenzaSpecification isInterventoBeyondTheScadenza = new IsInterventoBeyondTheScadenzaSpecification(dataConsuntivazione, _ScadenzaConsuntivazioneAppaltatore);

            ISpecification<Intervento> specs = isInterventoBeyondTheScadenza;

            if (specs.IsSatisfiedBy(this, messagiValidazione))
            {
                var evt = new ConsAppaltatoreNonResoAmbCreato()
                {
                    IdInterventoAppaltatore = idInterventoAppaltatore,
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

        public void OnConsAppaltatoreNonResoAmbCreato(ConsAppaltatoreNonResoAmbCreato e)
        {
            var consuntivo = new ConsAppaltatoreAmbNonReso(e.IdInterventoAppaltatore, e.DataConsuntivazione, e.IdCausale);

            ConsuntivazioneAppaltatore = consuntivo;
        }
        

        public void ConsuntivaNonResoTrenitaliaDaAppaltatore(string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
        {
            List<string> messagiValidazione = new List<string>();

            IsInterventoBeyondTheScadenzaSpecification isInterventoBeyondTheScadenza = new IsInterventoBeyondTheScadenzaSpecification(dataConsuntivazione, _ScadenzaConsuntivazioneAppaltatore);
            IsInterventoSpuntatoSpecification isInterventoSpuntato = new IsInterventoSpuntatoSpecification();

            ISpecification<Intervento> specs = isInterventoBeyondTheScadenza.And(isInterventoSpuntato);

            if (specs.IsSatisfiedBy(this, messagiValidazione))
            {

                var evt = new ConsAppaltatoreAmbNonResoTrenitaliaCreato()
                {
                    IdInterventoAppaltatore = idInterventoAppaltatore,
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

        public void OnConsAppaltatoreAmbNonResoTrenitaliaCreato(ConsAppaltatoreAmbNonResoTrenitaliaCreato e)
        {
            var consuntivo = new ConsAppaltatoreAmbNonResoTrenitalia(e.IdInterventoAppaltatore, e.DataConsuntivazione, e.IdCausale);
            ConsuntivazioneAppaltatore = consuntivo;
        }


        public override int GetTimeOutConsuntivazioneAppaltatore()
        {
            return _ScadenzaConsuntivazioneAppaltatore;
        }

    }
}
