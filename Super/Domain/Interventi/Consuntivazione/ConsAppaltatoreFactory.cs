using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi.Consuntivazione
{
    public class ConsAppaltatoreFactory
    {
        public static IOggettoInterventoRotContainer GetConsuntivoRot(Guid idIntervento, DateTime dataConsuntivazione, string idInterventoAppaltatore, DateTime inizio, DateTime fine)
        {
            return new ConsAppaltatoreRotReso(Guid.NewGuid(),
                                              idIntervento,
                                              new OggettoInterventoRotContainer(),
                                              dataConsuntivazione,
                                              idInterventoAppaltatore,
                                              inizio,
                                              fine);
        }

        public static IOggettoInterventoRotManContainer GetConsuntivoRotMan(Guid idIntervento, DateTime dataConsuntivazione, string idInterventoAppaltatore, DateTime inizio, DateTime fine)
        {
            return new ConsAppaltatoreRotManReso(Guid.NewGuid(),
                                                 idIntervento,
                                                 new OggettoInterventoRotManContainer(),
                                                 dataConsuntivazione,
                                                 idInterventoAppaltatore,
                                                 inizio,
                                                 fine);
        }
    }
}
