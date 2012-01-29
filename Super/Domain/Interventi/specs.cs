using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi
{
    public class HasAlreadyBeenConsuntivatedByTrenitaliaSpecification : ISpecification<Intervento>
    {
        public bool IsSatisfiedBy(Intervento i, List<string> messagiValidazione)
        {

            if (i.StatoTrenitalia!=null)
            {
                messagiValidazione.Add("Fatale : Has already been consuntivated by trenitalia");
                return false;
            }

            return true;
        }
    }

    public class IsInterventoSpuntatoSpecification : ISpecification<Intervento>
    {
        public bool IsSatisfiedBy(Intervento i, List<string> messagiValidazione)
        {
            if (!i.IsSpunta)
            {
                messagiValidazione.Add("Fatale : Intervento is spuntato");
                return false;
            }

            return true;
        }
    }

    public class IsInterventoBeyondThe20MinutesSpecification : ISpecification<Intervento>
    {
        DateTime _DataConsuntivazione;
        int _TimeOutConsuntivazioneAppaltatore;

        public IsInterventoBeyondThe20MinutesSpecification(DateTime dataConsuntivazione, int timeOutConsuntivazioneAppaltatore)
        {
            _DataConsuntivazione = dataConsuntivazione;
            _TimeOutConsuntivazioneAppaltatore = timeOutConsuntivazioneAppaltatore;
        }

        public bool IsSatisfiedBy(Intervento i, List<string> messagiValidazione)
        {
            if (i.FineScheduled.AddMinutes(_TimeOutConsuntivazioneAppaltatore) > _DataConsuntivazione)
            {
                messagiValidazione.Add("Fatale : Intervento is beyond the 20 minutes");
                return false;
            }

            return true;
        }
    }
}
