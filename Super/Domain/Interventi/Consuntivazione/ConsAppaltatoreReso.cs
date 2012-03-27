using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using Events.Interventi;
using Ncqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;

namespace Domain.Interventi.Consuntivazione
{
    public abstract class ConsAppaltatoreReso : ConsAppaltatore
    {
        public string idInterventoAppaltatore { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }

        public ConsAppaltatoreReso(Guid id)
            : base(id)
        {

        }
    }

    [DynamicSnapshot]
    public class ConsAppaltatoreRotReso : ConsAppaltatoreReso, IOggettoInterventoRotContainer
    {
        private IOggettoInterventoRotContainer _OggettoInterventoRotContainer;
        public IEnumerable<OggettoInterventoRot> Oggetti
        {
            get { return _OggettoInterventoRotContainer.Oggetti; }
        }

        public ConsAppaltatoreRotReso(Guid id, Guid idIntervento, IOggettoInterventoRotContainer oggettoInterventoRotContainer, DateTime dataConsuntivazione, string idInterventoAppaltatore, DateTime inizio, DateTime fine)
            : base(id)
        {
            Contract.Requires<ArgumentNullException>(oggettoInterventoRotContainer != null);

            _OggettoInterventoRotContainer = oggettoInterventoRotContainer;

            ConsAppaltatoreRotResoCreato evt = new ConsAppaltatoreRotResoCreato()
            {
                IdIntervento = idIntervento,
                IdInterventoAppaltatore = idInterventoAppaltatore,
                DataConsuntivazione = dataConsuntivazione,
                Fine = fine,
                Inizio = inizio
            };
            ApplyEvent(evt);
        }

        public void AddOggetto(string descrizione, Guid idTipoOggettoInterventoRot, int quantita)
        {
            _OggettoInterventoRotContainer.AddOggetto(descrizione, idTipoOggettoInterventoRot, quantita);
        }

        public void OnConsAppaltatoreRotResoCreato(ConsAppaltatoreRotResoCreato e)
        {
            DataConsuntivazione = e.DataConsuntivazione;
            idInterventoAppaltatore = e.IdInterventoAppaltatore;
            Inizio = e.Inizio;
            Fine = e.Fine;
        }


    }

    [DynamicSnapshot]
    public class ConsAppaltatoreRotManReso : ConsAppaltatoreReso, IOggettoInterventoRotManContainer
    {
        private IOggettoInterventoRotManContainer _OggettoInterventoRotManContainer;

        public ConsAppaltatoreRotManReso(Guid id, Guid idIntervento, IOggettoInterventoRotManContainer oggettoInterventoRotManContainer, DateTime dataConsuntivazione, string idInterventoAppaltatore, DateTime inizio, DateTime fine)
            : base(id)
        {
            Contract.Requires<ArgumentNullException>(oggettoInterventoRotManContainer != null);

            _OggettoInterventoRotManContainer = oggettoInterventoRotManContainer;

            ConsAppaltatoreRotManResoCreato evt = new ConsAppaltatoreRotManResoCreato()
            {
                IdIntervento = idIntervento,
                IdInterventoAppaltatore = idInterventoAppaltatore,
                DataConsuntivazione = dataConsuntivazione,
                Fine = fine,
                Inizio = inizio
            };
            ApplyEvent(evt);
        }

        public IEnumerable<OggettoInterventoRotMan> Oggetti
        {
            get { return _OggettoInterventoRotManContainer.Oggetti}
        }

        public void AddOggetto(string descrizione, Guid idTipoOggettoInterventoRotMan, int quantita)
        {
            _OggettoInterventoRotManContainer.AddOggetto(descrizione, idTipoOggettoInterventoRotMan, quantita);
        }


        public void OnConsAppaltatoreRotManResoCreato(ConsAppaltatoreRotManResoCreato e)
        {
            DataConsuntivazione = e.DataConsuntivazione;
            idInterventoAppaltatore = e.IdInterventoAppaltatore;
            Inizio = e.Inizio;
            Fine = e.Fine;
        }
    }

    [DynamicSnapshot]
    public class ConsAppaltatoreAmbReso : ConsAppaltatoreReso
    {
        public ConsAppaltatoreAmbReso(Guid id, Guid idIntervento,  DateTime dataConsuntivazione, string idInterventoAppaltatore, DateTime inizio, DateTime fine)
            : base(id)
        {
            ConsAppaltatoreAmbResoCreato evt = new ConsAppaltatoreAmbResoCreato()
            {
                IdIntervento = idIntervento,
                IdInterventoAppaltatore = idInterventoAppaltatore,
                DataConsuntivazione = dataConsuntivazione,
                Fine = fine,
                Inizio = inizio
            };
            ApplyEvent(evt);
        }

        public void OnConsAppaltatoreAmbResoCreato(ConsAppaltatoreAmbResoCreato e)
        {
            DataConsuntivazione = e.DataConsuntivazione;
            idInterventoAppaltatore = e.IdInterventoAppaltatore;
            Inizio = e.Inizio;
            Fine = e.Fine;
        }
    }

}
