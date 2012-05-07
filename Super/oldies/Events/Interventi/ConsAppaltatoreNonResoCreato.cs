using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Interventi
{
    [Serializable]
    public abstract class ConsAppaltatoreNonResoCreato
    {
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }
    }

    [Serializable]
    public class ConsAppaltatoreNonResoRotCreato : ConsAppaltatoreNonResoCreato
    { }

    [Serializable]
    public class ConsAppaltatoreNonResoRotManCreato : ConsAppaltatoreNonResoCreato
    { }

    [Serializable]
    public class ConsAppaltatoreNonResoAmbCreato : ConsAppaltatoreNonResoCreato
    { }
}
