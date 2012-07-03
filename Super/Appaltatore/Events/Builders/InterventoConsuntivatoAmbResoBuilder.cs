using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoConsuntivatoAmbResoBuilder : IEventBuilder<InterventoConsuntivatoAmbReso>
    {
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private WorkPeriod _period;
        private string _note;
        private int _quantity;
        private string _description;


        public InterventoConsuntivatoAmbResoBuilder ForQuantity(int quantity)
        {
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


        public InterventoConsuntivatoAmbResoBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
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


        public InterventoConsuntivatoAmbReso Build(Guid id, long version)
        {

            return new InterventoConsuntivatoAmbReso(id, Guid.NewGuid(), version, _idInterventoAppaltatore, _dataConsuntivazione, _period, _note, _quantity, _description);
        }

    }
}