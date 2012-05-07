using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Executors.Interventi
{
    public static class ExtensionMethods
    {

        public static IEnumerable<Domain.Interventi.OggettoInterventoRot> ToDomainOggettiRot(this IEnumerable<Commands.Interventi.OggettoRot> oggetti)
        {
            return oggetti.Select(x => new Domain.Interventi.OggettoInterventoRot()
                    {
                        Descrizione = x.Descrizione,
                        IdTipoOggettoInterventoRot = x.IdTipoOggettoInterventoRot,
                        Quantita = x.Quantita
                    });
        }

        public static IEnumerable<Domain.Interventi.OggettoInterventoRotMan> ToDomainOggettiRotMan(this IEnumerable<Commands.Interventi.OggettoRotMan> oggetti)
        {
            return oggetti.Select(x => new Domain.Interventi.OggettoInterventoRotMan()
            {
                Descrizione = x.Descrizione,
                IdTipoOggettoInterventoRotMan = x.IdTipoOggettoInterventoRotMan,
                Quantita = x.Quantita
            });
        }
    }
}
