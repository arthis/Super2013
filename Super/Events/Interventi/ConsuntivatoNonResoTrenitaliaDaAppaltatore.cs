using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Interventi
{
    [Serializable]
    public abstract class InterventoConsuntivatoNonResoTrenitaliaDaAppaltatore
    {
        public int IdInterventoSuper { get; set; }
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }
    }

    [Serializable]
    public class InterventoRotabileConsuntivatoNonResoTrenitaliaDaAppaltatore : InterventoConsuntivatoNonResoTrenitaliaDaAppaltatore
    { }

    [Serializable]
    public class InterventoRotabileInManutenzioneConsuntivatoNonResoTrenitaliaDaAppaltatore : InterventoConsuntivatoNonResoTrenitaliaDaAppaltatore
    { }

    [Serializable]
    public class InterventoAmbientiConsuntivatoNonResoTrenitaliaDaAppaltatore : InterventoConsuntivatoNonResoTrenitaliaDaAppaltatore
    { }
}
