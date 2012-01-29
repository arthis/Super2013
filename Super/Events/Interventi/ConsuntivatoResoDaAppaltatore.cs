using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Interventi
{
    [Serializable]
    public abstract class InterventoConsuntivatoResoDaAppaltatore
    {
        public int IdInterventoSuper { get; set; }
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
    }

    [Serializable]
    public class InterventoRotabileConsuntivatoResoDaAppaltatore : InterventoConsuntivatoResoDaAppaltatore
    { }

    [Serializable]
    public class InterventoRotabileInManutenzioneConsuntivatoResoDaAppaltatore : InterventoConsuntivatoResoDaAppaltatore
    { }

    [Serializable]
    public class InterventoAmbientiConsuntivatoResoDaAppaltatore : InterventoConsuntivatoResoDaAppaltatore
    { }
}
