using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Controllo.Events.Builders
{
    public class InterventoAmbControlledResoBuilder : IEventBuilder<IEvent>
    {
        private Guid _idUtente;
        private DateTime _controlDate;
        private string _note;
        private WorkPeriod _period;
        private int _quantity;
        private string _description;

        

        public InterventoAmbControlledResoBuilder By(Guid idUtente)
        {
            _idUtente = idUtente;
            return this;
        }

        public InterventoAmbControlledResoBuilder When(DateTime controlDate)
        {
            _controlDate = controlDate;
            return this;
        }

        public InterventoAmbControlledResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoAmbControlledResoBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public InterventoAmbControlledResoBuilder WithQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public InterventoAmbControlledResoBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public IEvent Build(Guid id)
        {
            var cmd = new InterventoAmbControlledReso(id, _idUtente, _controlDate, _period, _note, _quantity, _description);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}