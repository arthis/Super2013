using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core.Super.Domain.Builders
{
    public static class Build
    {
        public static IntervalBuilder Interval { get { return new IntervalBuilder(); } }
        public static OggettoRotManBuilder OggettoRotMan { get { return new OggettoRotManBuilder(); } }
        public static OggettoRotBuilder OggettoRot { get { return new OggettoRotBuilder(); } }
    }
}
