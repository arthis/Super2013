using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Interventi
{
    [Serializable]
    public abstract class InterventoConsuntivatoNonResoDaAppaltatore
    {
        public int IdInterventoSuper { get; set; }
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
    }

    [Serializable]
    public class InterventoRotabileConsuntivatoNonResoDaAppaltatore : InterventoConsuntivatoNonResoDaAppaltatore
    { }

    [Serializable]
    public class InterventoRotabileInManutenzioneConsuntivatoNonResoDaAppaltatore : InterventoConsuntivatoNonResoDaAppaltatore
    { }

    [Serializable]
    public class InterventoAmbientiConsuntivatoNonResoDaAppaltatore : InterventoConsuntivatoNonResoDaAppaltatore
    { }
}
