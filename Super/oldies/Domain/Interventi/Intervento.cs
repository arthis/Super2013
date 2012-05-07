using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Domain;
using Events;
using Domain.Interventi.Consuntivazione;
using Events.Interventi;

namespace Domain.Interventi
{
    public abstract class Intervento : AggregateRootMappedByConvention
    {
        private int _TimeOutConsuntivazioneAppaltatore = 20;
        private DateTime? _DataSpunta;
        private bool _IsInterventoEffetuato;
        private bool _IsInibito;

        public ConsAppaltatore ConsuntivazioneAppaltatore { get; set; }
        public ConsTrenitalia ConsuntivazioneTrenitalia { get; set; }
        
        public DateTime? DataSpunta
        {
            get { return _DataSpunta; }
        }
        public bool IsSpunta
        {
            get { return DataSpunta.HasValue; }
        }
        public bool IsInibito
        {
            get { return _IsInibito; }
        }
        public bool IsInterventoEffetuato 
        {
            get  { return _IsInterventoEffetuato; }
            set { _IsInterventoEffetuato = value; }
        }
        

        public int IdInterventoSuper { get; set; }
        public string IdInterventoAppaltatore { get; set; }
        public DateTime InizioScheduled { get; set; }
        public DateTime FineScheduled { get; set; }
        public Guid IdAreaIntervento { get; set; }
        public Guid IdCommittente { get; set; }

        public Intervento()
        {
        }

        public Intervento(Guid id) :  base(id)
        {
            
        }

        public abstract int GetTimeOutConsuntivazioneAppaltatore();

        public void Inibire()
        {
            var evt = new InterventoInibito();
            ApplyEvent(evt);
        }

        public void Disinibire()
        {
            var evt = new InterventoDisinibito();
            ApplyEvent(evt);
        }

        public void OnInterventoInibito(InterventoInibito e)
        {
            _IsInibito = true;
        }

        public void OnInterventoDisinibito(InterventoDisinibito e)
        {
            _IsInibito = false;
        }
     
    }
}
