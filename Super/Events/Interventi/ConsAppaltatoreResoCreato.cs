using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Interventi
{
    [Serializable]
    public abstract class ConsAppaltatoreResoCreato
    {
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public string Note { get; set; }
    }

    [Serializable]
    public class ConsAppaltatoreRotResoCreato : ConsAppaltatoreResoCreato
    {
        public IEnumerable<OggettoRot> Oggetti { get; set; }
    }

    [Serializable]
    public class ConsAppaltatoreRotManResoCreato : ConsAppaltatoreResoCreato
    {
        public IEnumerable<OggettoRotMan> Oggetti { get; set; }
    }

    [Serializable]
    public class ConsAppaltatoreAmbResoCreato : ConsAppaltatoreResoCreato
    { }
}
