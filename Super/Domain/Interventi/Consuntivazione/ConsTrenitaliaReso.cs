using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Domain.Interventi.Consuntivazione
{
    public abstract class ConsTrenitaliaReso : ConsTrenitalia
    {
        public string idInterventoTrenitalia { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
    }

    public class ConsTrenitaliaResoRot : ConsTrenitaliaReso, IOggettoInterventoRotContainer
    {
        private IOggettoInterventoRotContainer _OggettoInterventoRotContainer;

        public ConsTrenitaliaResoRot(IOggettoInterventoRotContainer oggettoInterventoRotContainer, DateTime dataConsuntivazione, DateTime inizio, DateTime fine)
        {
            Contract.Requires<ArgumentNullException>(oggettoInterventoRotContainer != null);

            _OggettoInterventoRotContainer = oggettoInterventoRotContainer;

            DataConsuntivazione = dataConsuntivazione;
            Inizio = inizio;
            Fine = fine;
        }

        public IEnumerable<OggettoInterventoRot> Oggetti
        {
            get { return _OggettoInterventoRotContainer.Oggetti; }
        }

        public void AddOggetto(string descrizione, Guid idTipoOggettoInterventoRot, int quantita)
        {
            _OggettoInterventoRotContainer.AddOggetto(descrizione, idTipoOggettoInterventoRot, quantita);
        }
    }

    public class ConsTrenitaliaResoRotMan : ConsTrenitaliaReso, IOggettoInterventoRotManContainer
    {
        private IOggettoInterventoRotManContainer _OggettoInterventoRotManContainer;

        public ConsTrenitaliaResoRotMan( IOggettoInterventoRotManContainer oggettoInterventoRotManContainer, DateTime dataConsuntivazione, DateTime inizio, DateTime fine)
        {
            Contract.Requires<ArgumentNullException>(oggettoInterventoRotManContainer != null);

            _OggettoInterventoRotManContainer = oggettoInterventoRotManContainer;

            DataConsuntivazione = dataConsuntivazione;
            Inizio = inizio;
            Fine = fine;
        }

        public IEnumerable<OggettoInterventoRotMan> Oggetti
        {
            get { return _OggettoInterventoRotManContainer.Oggetti; }
        }

        public void AddOggetto(string descrizione, Guid idTipoOggettoInterventoRotMan, int quantita)
        {
            _OggettoInterventoRotManContainer.AddOggetto(descrizione, idTipoOggettoInterventoRotMan, quantita);
        }
    }

    public class ConsTrenitaliaResoAmb : ConsTrenitaliaReso
    {
        public ConsTrenitaliaResoAmb(DateTime dataConsuntivazione, DateTime inizio, DateTime fine)
        {
            DataConsuntivazione = dataConsuntivazione;
            Inizio = inizio;
            Fine = fine;
        }
    }

}
