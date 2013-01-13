using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Super.Contabilita.Domain.Builders;


namespace Super.Contabilita.Domain
{
    public static class Build
    {
        public static BasePriceRotBuilder BasePriceRot { get { return new BasePriceRotBuilder();}}
        public static BasePriceRotManBuilder BasePriceRotMan { get { return new BasePriceRotManBuilder(); } }
        public static BasePriceAmbBuilder BasePriceAmb { get { return new BasePriceAmbBuilder(); } }

        public static OggettoInterventoRotBuilder OggettoInterventoRot { get { return new OggettoInterventoRotBuilder(); } }
    }
}
