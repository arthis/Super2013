using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core.Super.Domain.Builders
{
    public static class Build
    {
        public static IntervallBuilder Intervall { get { return new IntervallBuilder(); } }
        public static OggettoRotManBuilder OggettoRotMan { get { return new OggettoRotManBuilder(); } }
        public static OggettoRotBuilder OggettoRot { get { return new OggettoRotBuilder(); } }
    }
}
