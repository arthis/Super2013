using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi
{
    public static class ExtensionMethods
    {

        public static IEnumerable<Events.Interventi.OggettoRot> ToEventsOggettiRot(this IEnumerable<OggettoInterventoRot> oggetti)
        {
            return oggetti.Select(x => new Events.Interventi.OggettoRot()
                    {
                        Descrizione = x.Descrizione,
                        IdTipoOggettoInterventoRot = x.IdTipoOggettoInterventoRot,
                        Quantita = x.Quantita
                    });
        }

        public static IEnumerable<Events.Interventi.OggettoRotMan> ToEventsOggettiRotMan(this IEnumerable<OggettoInterventoRotMan> oggetti)
        {
            return oggetti.Select(x => new Events.Interventi.OggettoRotMan()
                    {
                        Descrizione = x.Descrizione,
                        IdTipoOggettoInterventoRotMan = x.IdTipoOggettoInterventoRotMan,
                        Quantita = x.Quantita
                    });
        }
    }
}
