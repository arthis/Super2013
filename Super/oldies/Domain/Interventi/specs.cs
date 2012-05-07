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

            if (i.ConsuntivazioneTrenitalia!=null)
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

    public class IsInterventoInibitoSpecification : ISpecification<Intervento>
    {
        public bool IsSatisfiedBy(Intervento i, List<string> messagiValidazione)
        {
            if (!i.IsInibito)
            {
                messagiValidazione.Add("Fatale : Intervento is inibito");
                return false;
            }

            return true;
        }
    }

    public class IsInterventoBeyondTheScadenzaSpecification : ISpecification<Intervento>
    {
        DateTime _DataConsuntivazione;
        int _TimeOutConsuntivazioneAppaltatore;

        public IsInterventoBeyondTheScadenzaSpecification(DateTime dataConsuntivazione, int scadenzaConsuntivazioneAppaltatore)
        {
            _DataConsuntivazione = dataConsuntivazione;
            _TimeOutConsuntivazioneAppaltatore = scadenzaConsuntivazioneAppaltatore;
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

    public class IsDataInizioFineValideSpecification : ISpecification<Intervento>
    {
        DateTime _Inizio;
        DateTime _Fine;
        

        public IsDataInizioFineValideSpecification(DateTime inizio, DateTime fine)
        {
            _Inizio = inizio;
            _Fine = fine;
        }

        public bool IsSatisfiedBy(Intervento i, List<string> messagiValidazione)
        {

            if (DateTime.MinValue==_Inizio)
            {
                messagiValidazione.Add("Fatale : Inizio  deve avere una valore valida");
                return false;
            }

            if (DateTime.MinValue == _Fine)
            {
                messagiValidazione.Add("Fatale : Fine  deve avere una valore valida");
                return false;
            }

            if (_Inizio.AddHours(-10) > i.InizioScheduled)
            {
                messagiValidazione.Add("Fatale : L'inizio dell'intervento consuntivato deve essere superiore alla data/ora inizio programmata meno 10 ore.");
                return false;
            }

            if (_Inizio > _Fine)
            {
                messagiValidazione.Add("Fatale : La fine dell'intervento consuntivato deve essere inferiore o uguale alla data/ora fine programmata.");
                return false;
            }

            return true;
        }
    }


    public class IsDataConsuntivazioneValidaSpecification : ISpecification<Intervento>
    {
        DateTime _Inizio;
        DateTime _DataConsuntivazione;


        public IsDataConsuntivazioneValidaSpecification(DateTime inizio, DateTime dataConsuntivazione)
        {
            _Inizio = inizio;
            _DataConsuntivazione = dataConsuntivazione;
        }

        public bool IsSatisfiedBy(Intervento i, List<string> messagiValidazione)
        {

            if (DateTime.MinValue == _DataConsuntivazione)
            {
                messagiValidazione.Add("Fatale : DataConsuntivazione  deve avere una valore valida");
                return false;
            }

            if (_Inizio.AddHours(-10) >  _DataConsuntivazione)
            {
                messagiValidazione.Add("Fatale : La data di consuntivazione deve essere superiore alla data/ora inizio programmata meno 10 ore.");
                return false;
            }

            return true;
        }
    }

   
}
