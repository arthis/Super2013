﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Domain;
using Cqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
using Events.Interventi;
using Domain.Interventi.Consuntivazione;



namespace Domain.Interventi
{
    [DynamicSnapshot]
    public class InterventoRotMan : Intervento, IOggettoInterventoRotManContainer
    {
        private int _ScadenzaConsuntivazioneAppaltatore = 20;

        private IOggettoInterventoRotManContainer _OggettoInterventoRotManContainer;
        public IEnumerable<OggettoInterventoRotMan> Oggetti
        {
            get { return _OggettoInterventoRotManContainer.Oggetti; }
        }
        public Guid IdTipoInterventoRotMan { get; set; }

        public InterventoRotMan()
        {
        }

        public InterventoRotMan(Guid id)
            : base(id)
        {
        }

        public void CrearePlg(int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, Guid idTipoIntervento, DateTime dataCreazione, IEnumerable<OggettoInterventoRotMan> oggetti)
        {
            InterventoPLGRotManCreato evt = new InterventoPLGRotManCreato()
            {
                InterventoIdSuper = interventoIdSuper,
                IdAreaIntervento = idAreaIntervento,
                Inizio = inizio,
                Fine = fine,
                IdTipoInterventoRotMan = idTipoIntervento,
                DataCreazione = dataCreazione,
                Oggetti = oggetti.ToEventsOggettiRotMan()
            };

            ApplyEvent(evt);
        }

        protected void OnInterventoPLGRotManCreato(InterventoPLGRotManCreato e)
        {
            this.IdInterventoSuper = e.InterventoIdSuper;
            this.InizioScheduled = e.Inizio;
            this.FineScheduled = e.Fine;
            this.IdAreaIntervento = e.IdAreaIntervento;
            this.IdTipoInterventoRotMan = e.IdTipoInterventoRotMan;

            foreach (Events.Interventi.OggettoRotMan o in e.Oggetti)
            {
                this.AddOggetto(o.Descrizione, o.IdTipoOggettoInterventoRotMan, o.Quantita);
            }
        }

        protected void OnInterventoCreato(InterventoRotManCreato e)
        {
            this.IdInterventoSuper = e.InterventoIdSuper;
            this.InizioScheduled = e.Inizio;
            this.FineScheduled = e.Fine;
            this.IdAreaIntervento = e.IdAreaIntervento;
        }


        public void ConsuntivaResoDaAppaltatore(string idInterventoAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, IEnumerable<OggettoInterventoRotMan> oggetti)
        {
            List<string> messagiValidazione = new List<string>();

            IsInterventoBeyondTheScadenzaSpecification isInterventoBeyondTheScadenza = new IsInterventoBeyondTheScadenzaSpecification(dataConsuntivazione, _ScadenzaConsuntivazioneAppaltatore);
            IsInterventoSpuntatoSpecification isInterventoSpuntato = new IsInterventoSpuntatoSpecification();

            ISpecification<Intervento> specs = isInterventoBeyondTheScadenza.And(isInterventoSpuntato);

            if (specs.IsSatisfiedBy(this, messagiValidazione))
            {

                var evt = new ConsAppaltatoreRotManResoCreato()
                {
                    IdInterventoAppaltatore = idInterventoAppaltatore,
                    DataConsuntivazione = dataConsuntivazione,
                    Fine = fine,
                    Inizio = inizio,
                    Oggetti = oggetti.ToEventsOggettiRotMan()
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


        public void OnConsAppaltatoreRotManResoCreato(ConsAppaltatoreRotManResoCreato e)
        {
            ConsAppaltatoreRotManReso consuntivo = ConsAppaltatoreFactory.GetConsuntivoRotMan(e.DataConsuntivazione,
                                                                                              e.IdInterventoAppaltatore,
                                                                                              e.Inizio,
                                                                                              e.Fine);
            foreach (Events.Interventi.OggettoRotMan o in e.Oggetti)
            {
                consuntivo.AddOggetto(o.Descrizione, o.IdTipoOggettoInterventoRotMan, o.Quantita);
            }

            ConsuntivazioneAppaltatore = consuntivo;
        }


        public void ConsuntivaNonResoDaAppaltatore(string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale)
        {
            List<string> messagiValidazione = new List<string>();

            IsInterventoBeyondTheScadenzaSpecification isInterventoBeyondTheScadenza = new IsInterventoBeyondTheScadenzaSpecification(dataConsuntivazione, _ScadenzaConsuntivazioneAppaltatore);

            ISpecification<Intervento> specs = isInterventoBeyondTheScadenza;

            if (specs.IsSatisfiedBy(this, messagiValidazione))
            {
                var evt = new ConsAppaltatoreNonResoRotManCreato()
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

        public void OnConsAppaltatoreNonResoRotManCreato(ConsAppaltatoreNonResoRotManCreato e)
        {
            var consuntivo = new ConsAppaltatoreRotManNonReso(e.IdInterventoAppaltatore, e.DataConsuntivazione, e.IdCausale);

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
                var evt = new ConsAppaltatoreRotManNonResoTrenitaliaCreato()
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

        public void OnConsAppaltatoreRotManNonResoTrenitaliaCreato(ConsAppaltatoreRotManNonResoTrenitaliaCreato e)
        {
            var consuntivo = new ConsAppaltatoreRotManNonResoTrenitalia(e.IdInterventoAppaltatore, e.DataConsuntivazione, e.IdCausale);
            ConsuntivazioneAppaltatore = consuntivo;
        }

        public void AddOggetto(string descrizione, Guid idTipoOggettoInterventoRotMan, int quantita)
        {
            _OggettoInterventoRotManContainer.AddOggetto(descrizione, idTipoOggettoInterventoRotMan, quantita);
        }



        public override int GetTimeOutConsuntivazioneAppaltatore()
        {
            return _ScadenzaConsuntivazioneAppaltatore;
        }


        
    }
}
