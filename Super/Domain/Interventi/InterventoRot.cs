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
    public class InterventoRot : Intervento, IOggettoInterventoRotContainer
    {
        private int _ScadenzaConsuntivazioneAppaltatore = 20;

        private IOggettoInterventoRotContainer _OggettoInterventoRotContainer;
        public IEnumerable<OggettoInterventoRot> Oggetti
        {
            get { return _OggettoInterventoRotContainer.Oggetti; }
        }

        public Guid IdTrenoPartenza { get; set; }
        public Guid IdTrenoArrivo { get; set; }
        public Guid IdTipoInterventoRot { get; set; }

        public InterventoRot()
        {

        }

        public InterventoRot(Guid id)
            : base(id)
        {

        }

        public void CrearePlg(int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, Guid idTipoIntervento, DateTime dataCreazione, IEnumerable<OggettoInterventoRot> oggetti)
        {
            InterventoPLGRotCreato evt = new InterventoPLGRotCreato()
            {
                InterventoIdSuper = interventoIdSuper,
                IdAreaIntervento = idAreaIntervento,
                Inizio = inizio,
                Fine = fine,
                IdTipoInterventoRot = idTipoIntervento,
                DataCreazione = dataCreazione,
                Oggetti = oggetti.ToEventsOggettiRot()
            };

            ApplyEvent(evt);
        }

        protected void OnInterventoPLGRotCreato(InterventoPLGRotCreato e)
        {
            this.IdInterventoSuper = e.InterventoIdSuper;
            this.InizioScheduled = e.Inizio;
            this.FineScheduled = e.Fine;
            this.IdAreaIntervento = e.IdAreaIntervento;
            this.IdTipoInterventoRot = e.IdTipoInterventoRot;
            
            foreach(Events.Interventi.OggettoRot o in e.Oggetti)
            {
                this.AddOggetto(o.Descrizione, o.IdTipoOggettoInterventoRot, o.Quantita);
            }
        }

        public void ConsuntivaResoDaAppaltatore(string idInterventoAppaltatore, DateTime dataConsuntivazione, DateTime inizio, DateTime fine, IEnumerable<OggettoInterventoRot> oggetti)
        {
            List<string> messagiValidazione = new List<string>();

            var isInterventoBeyondTheScadenza = new IsInterventoBeyondTheScadenzaSpecification(dataConsuntivazione, _ScadenzaConsuntivazioneAppaltatore);
            var isInterventoSpuntato = new IsInterventoSpuntatoSpecification();
            var isInterventoInibito = new IsInterventoInibitoSpecification();
            var isDataInizioFineValide = new IsDataInizioFineValideSpecification(inizio, fine);
            var isDataConsuntivazioneValida = new IsDataConsuntivazioneValidaSpecification(inizio, dataConsuntivazione);

            ISpecification<Intervento> specs = isInterventoBeyondTheScadenza.And(isInterventoSpuntato)
                                                                             .And(isInterventoInibito)
                                                                             .And(isDataInizioFineValide)
                                                                             .And(isDataConsuntivazioneValida);

            if (specs.IsSatisfiedBy(this, messagiValidazione))
            {

                var evt = new ConsAppaltatoreRotResoCreato()
                {
                    IdInterventoAppaltatore = idInterventoAppaltatore,
                    DataConsuntivazione = dataConsuntivazione,
                    Fine = fine,
                    Inizio = inizio,
                    Oggetti = oggetti.ToEventsOggettiRot()
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

        public void OnConsAppaltatoreRotResoCreato(ConsAppaltatoreRotResoCreato e)
        {
            ConsAppaltatoreRotReso consuntivo = ConsAppaltatoreFactory.GetConsuntivoRot(e.DataConsuntivazione,
                                                                                        e.IdInterventoAppaltatore,
                                                                                        e.Inizio,
                                                                                        e.Fine);
            foreach (Events.Interventi.OggettoRot o in e.Oggetti)
            {
                consuntivo.AddOggetto(o.Descrizione, o.IdTipoOggettoInterventoRot, o.Quantita);
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
                var evt = new ConsAppaltatoreNonResoRotCreato()
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

        public void OnConsAppaltatoreNonResoRotCreato(ConsAppaltatoreNonResoRotCreato e)
        {
            var consuntivo = new ConsAppaltatoreRotNonReso(e.IdInterventoAppaltatore, e.DataConsuntivazione, e.IdCausale);

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

                var evt = new ConsAppaltatoreRotNonResoTrenitaliaCreato()
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


        public void OnConsAppaltatoreRotNonResoTrenitaliaCreato(ConsAppaltatoreRotNonResoTrenitaliaCreato e)
        {
            var consuntivo = new ConsAppaltatoreRotNonResoTrenitalia(e.IdInterventoAppaltatore, e.DataConsuntivazione, e.IdCausale);
            ConsuntivazioneAppaltatore = consuntivo;
        }

        public void AddOggetto(string descrizione, Guid idTipoOggettoInterventoRot, int quantita)
        {
            _OggettoInterventoRotContainer.AddOggetto(descrizione, idTipoOggettoInterventoRot, quantita);
        }

        public override int GetTimeOutConsuntivazioneAppaltatore()
        {
            return _ScadenzaConsuntivazioneAppaltatore;
        }



    }
}
