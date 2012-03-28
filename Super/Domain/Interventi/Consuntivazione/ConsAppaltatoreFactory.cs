using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi.Consuntivazione
{
    public class ConsAppaltatoreFactory
    {
        public static ConsAppaltatoreRotReso GetConsuntivoRot(DateTime dataConsuntivazione, string idInterventoAppaltatore, DateTime inizio, DateTime fine)
        {
            return new ConsAppaltatoreRotReso(new OggettoInterventoRotContainer(),
                                              dataConsuntivazione,
                                              idInterventoAppaltatore,
                                              inizio,
                                              fine);
        }

        public static ConsAppaltatoreRotManReso GetConsuntivoRotMan(DateTime dataConsuntivazione, string idInterventoAppaltatore, DateTime inizio, DateTime fine)
        {
            return new ConsAppaltatoreRotManReso(new OggettoInterventoRotManContainer(),
                                                 dataConsuntivazione,
                                                 idInterventoAppaltatore,
                                                 inizio,
                                                 fine);
        }
    }
}
