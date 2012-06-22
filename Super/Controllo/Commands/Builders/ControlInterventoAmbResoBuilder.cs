using System;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Controllo.Commands.Builders
{
    public class ControlInterventoAmbResoBuilder
    {
        private Guid _id;
        private Guid _idUtente;
        private DateTime _controlDate;
        private string _note;
        private WorkPeriod _period;
        private int _quantity;
        private string _description;

        public ControlInterventoAmbResoBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public ControlInterventoAmbResoBuilder By(Guid idUtente)
        {
            _idUtente = idUtente;
            return this;
        }

        public ControlInterventoAmbResoBuilder When(DateTime controlDate)
        {
            _controlDate = controlDate;
            return this;
        }

        public ControlInterventoAmbResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public ControlInterventoAmbResoBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public ControlInterventoAmbResoBuilder WithQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public ControlInterventoAmbResoBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public ControlInterventoAmbReso Build()
        {
            var cmd = new ControlInterventoAmbReso(_id, _idUtente, _controlDate, _period, _note, _quantity, _description);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}