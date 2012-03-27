using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Interventi;

namespace Domain.Interventi
{
    public class OggettoInterventoRotContainer : IOggettoInterventoRotContainer
    {
        private List<OggettoInterventoRot> _Oggetti;

        public DateTime DataConsuntivazione { get; set; }
        public IEnumerable<OggettoInterventoRot> Oggetti
        {
            get
            {
                if (_Oggetti == null)
                    _Oggetti = new List<OggettoInterventoRot>();
                return _Oggetti;
            }
        }

        public void AddOggetto(string descrizione, Guid idTipoOggettoInterventoRot, int quantita)
        {
            var evt = new OggettoInterventoRotAdded()
            {
                Descrizione = descrizione,
                IdTipoOggettoInterventoRot = idTipoOggettoInterventoRot,
                Quantita = quantita
            };
            //ApplyEvents
        }


        public void OnOggettoInterventoRotAdded(OggettoInterventoRotAdded e)
        {
            _Oggetti.Add(new OggettoInterventoRot()
            {
                Descrizione = e.Descrizione,
                IdTipoOggettoInterventoRot = e.IdTipoOggettoInterventoRot,
                Quantita = e.Quantita
            });
        }
    }
}
