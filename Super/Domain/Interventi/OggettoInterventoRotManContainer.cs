using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Interventi;

namespace Domain.Interventi
{
    public class OggettoInterventoRotManContainer : IOggettoInterventoRotManContainer
    {
        private List<OggettoInterventoRotMan> _Oggetti;

        public DateTime DataConsuntivazione { get; set; }
        public IEnumerable<OggettoInterventoRotMan> Oggetti
        {
            get
            {
                if (_Oggetti == null)
                    _Oggetti = new List<OggettoInterventoRotMan>();
                return _Oggetti;
            }
        }

        public void AddOggetto(string descrizione, Guid idTipoOggettoInterventoRotMan, int quantita)
        {
            var evt = new OggettoInterventoRotManAdded()
            {
                Descrizione = descrizione,
                IdTipoOggettoInterventoRotMan = idTipoOggettoInterventoRotMan,
                Quantita = quantita
            };
            //ApplyEvents
        }

        public void OnOggettoInterventoRotManAdded(OggettoInterventoRotManAdded e)
        {
            _Oggetti.Add(new OggettoInterventoRotMan()
            {
                Descrizione = e.Descrizione,
                IdTipoOggettoInterventoRotMan = e.IdTipoOggettoInterventoRotMan,
                Quantita = e.Quantita
            });
        }
    }
}
