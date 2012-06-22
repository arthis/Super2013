using System;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Controllo.Events.Builders
{
    public class InterventoAmbControlledResoBuilder
    {
        private Guid _id;
        private Guid _idUtente;
        private DateTime _controlDate;
        private string _note;
        private WorkPeriod _period;
        private int _quantity;
        private string _description;

        public InterventoAmbControlledResoBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

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

        public InterventoAmbControlledReso Build()
        {
            var cmd = new InterventoAmbControlledReso(_id, _idUtente, _controlDate, _period, _note, _quantity, _description);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}