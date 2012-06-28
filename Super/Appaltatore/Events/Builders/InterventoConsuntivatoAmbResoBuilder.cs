using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoConsuntivatoAmbResoBuilder
    {
        private Guid _id;
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private WorkPeriod _period;
        private string _note;
        private int _quantity;
        private string _description;


        public InterventoConsuntivatoAmbResoBuilder ForQuantity(int quantity)
        {
           Contract.Requires<ArgumentException>(this._quantity <= 0);

 
            _quantity = quantity;
            return this;
        }

        public InterventoConsuntivatoAmbResoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public InterventoConsuntivatoAmbResoBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public InterventoConsuntivatoAmbResoBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public InterventoConsuntivatoAmbResoBuilder ForInterventoAppaltatore(string IdInterventoAppaltatore)
        {
            _idInterventoAppaltatore = IdInterventoAppaltatore;
            return this;
        }

        public InterventoConsuntivatoAmbResoBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public InterventoConsuntivatoAmbResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }


        public InterventoConsuntivatoAmbReso Build()
        {
            return new InterventoConsuntivatoAmbReso(_id, _idInterventoAppaltatore, _dataConsuntivazione, _period, _note, _quantity, _description);
        }

    }
}