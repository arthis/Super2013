using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using Events.Interventi;


namespace Domain.Interventi.Consuntivazione
{
    
    public abstract class ConsAppaltatoreReso : ConsAppaltatore
    {
        public string IdInterventoAppaltatore { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }

    }

   
    public class ConsAppaltatoreRotReso : ConsAppaltatoreReso, IOggettoInterventoRotContainer
    {
        private IOggettoInterventoRotContainer _OggettoInterventoRotContainer;
        public IEnumerable<OggettoInterventoRot> Oggetti
        {
            get { return _OggettoInterventoRotContainer.Oggetti; }
        }

        public ConsAppaltatoreRotReso(IOggettoInterventoRotContainer oggettoInterventoRotContainer, DateTime dataConsuntivazione, string idInterventoAppaltatore, DateTime inizio, DateTime fine)
        {
            Contract.Requires<ArgumentNullException>(oggettoInterventoRotContainer != null);

            _OggettoInterventoRotContainer = oggettoInterventoRotContainer;

            DataConsuntivazione = dataConsuntivazione;
            IdInterventoAppaltatore = IdInterventoAppaltatore;
            Inizio = inizio;
            Fine = fine;
        }

        public void AddOggetto(string descrizione, Guid idTipoOggettoInterventoRot, int quantita)
        {
            _OggettoInterventoRotContainer.AddOggetto(descrizione, idTipoOggettoInterventoRot, quantita);
        }

    }

   
    public class ConsAppaltatoreRotManReso : ConsAppaltatoreReso, IOggettoInterventoRotManContainer
    {
        private IOggettoInterventoRotManContainer _OggettoInterventoRotManContainer;

        public ConsAppaltatoreRotManReso( IOggettoInterventoRotManContainer oggettoInterventoRotManContainer, DateTime dataConsuntivazione, string idInterventoAppaltatore, DateTime inizio, DateTime fine)
        {
            Contract.Requires<ArgumentNullException>(oggettoInterventoRotManContainer != null);

            _OggettoInterventoRotManContainer = oggettoInterventoRotManContainer;

            DataConsuntivazione = dataConsuntivazione;
            IdInterventoAppaltatore = IdInterventoAppaltatore;
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

   
    public class ConsAppaltatoreAmbReso : ConsAppaltatoreReso
    {
        public ConsAppaltatoreAmbReso( DateTime dataConsuntivazione, string idInterventoAppaltatore, DateTime inizio, DateTime fine)
        {
            DataConsuntivazione = dataConsuntivazione;
            IdInterventoAppaltatore = IdInterventoAppaltatore;
            Inizio = inizio;
            Fine = fine;
        }

     
    }

}
