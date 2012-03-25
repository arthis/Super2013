using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Domain;
using Events;
using Domain.Interventi.Stati;

namespace Domain.Interventi
{
    public abstract class Intervento : AggregateRootMappedByConvention
    {
        private int _TimeOutConsuntivazioneAppaltatore = 20;
        private DateTime? _DataSpunta;
        private DateTime? _DataConsuntivazioneAppaltatoreScaduta;

        public StatoAppaltatore StatoAppaltatore { get; set; }
        public StatoTrenitalia StatoTrenitalia { get; set; }
        
        public DateTime? DataSpunta
        {
            get { return _DataSpunta; }
        }
        public bool IsSpunta
        {
            get { return DataSpunta.HasValue; }
        }
        public bool IsConsuntivazioneAppaltatoreScaduta
        {
            get { return _DataConsuntivazioneAppaltatoreScaduta.HasValue; }
        }
        

        public int IdInterventoSuper { get; set; }
        public string IdInterventoAppaltatore { get; set; }
        public DateTime InizioScheduled { get; set; }
        public DateTime FineScheduled { get; set; }
        public Guid IdAreaIntervento { get; set; }
        public Guid IdTipoIntervento { get; set; }
        public Guid IdCommittente { get; set; }

        public Intervento()
        {
        }

        public Intervento(Guid id) :  base(id)
        {
        }

        public abstract int GetTimeOutConsuntivazioneAppaltatore();
    }
}
