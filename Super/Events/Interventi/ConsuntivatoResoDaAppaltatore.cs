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
        public string Note { get; set; }
    }

    [Serializable]
    public class InterventoRotConsuntivatoResoDaAppaltatore : InterventoConsuntivatoResoDaAppaltatore
    {

    }

    [Serializable]
    public class InterventoRotManConsuntivatoResoDaAppaltatore : InterventoConsuntivatoResoDaAppaltatore
    { }

    [Serializable]
    public class InterventoAmbConsuntivatoResoDaAppaltatore : InterventoConsuntivatoResoDaAppaltatore
    { }
}
