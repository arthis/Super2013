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
        public Guid IdCausale { get; set; }
    }

    [Serializable]
    public class InterventoRotConsuntivatoNonResoDaAppaltatore : InterventoConsuntivatoNonResoDaAppaltatore
    { }

    [Serializable]
    public class InterventoRotManConsuntivatoNonResoDaAppaltatore : InterventoConsuntivatoNonResoDaAppaltatore
    { }

    [Serializable]
    public class InterventoAmbConsuntivatoNonResoDaAppaltatore : InterventoConsuntivatoNonResoDaAppaltatore
    { }
}
