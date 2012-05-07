using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Interventi
{
    [Serializable]
    public class ConsuntivazioneResoDaAppaltatoreRejected
    {
        public Guid Id { get; set; }
        public int IdInterventoSuper { get; set; }
        public string IdInterventoAppaltatore { get; set; }
        public IEnumerable<string> Messaggio { get; set; }
    }
}
