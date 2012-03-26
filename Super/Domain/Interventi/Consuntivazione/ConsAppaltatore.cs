using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Interventi;

namespace Domain.Interventi.Consuntivazione
{
    public abstract class ConsAppaltatore
    {
        public DateTime DataConsuntivazione { get; set; }

    }

    public abstract class ConsAppaltatoreRot : ConsAppaltatore
    {
        private List<OggettoIntervento> _Oggetti;

        public DateTime DataConsuntivazione { get; set; }
        public IEnumerable<OggettoIntervento> Oggetti
        {
            get
            {
                if (_Oggetti == null)
                    _Oggetti = new List<OggettoIntervento>();
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
            ApplyEven
        }

        public void OnOggettoInterventoRotAdded(OggettoInterventoRotAdded e)
        {

        }
    }
}
