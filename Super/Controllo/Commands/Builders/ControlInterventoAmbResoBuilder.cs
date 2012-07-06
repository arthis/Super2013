using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Controllo.Commands.Builders
{
    public class ControlInterventoAmbResoBuilder: ICommandBuilder<ControlInterventoAmbReso>
    {
        private Guid _idUtente;
        private DateTime _controlDate;
        private string _note;
        private WorkPeriod _period;
        private int _quantity;
        private string _description;


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

        public ControlInterventoAmbResoBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public ControlInterventoAmbResoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public ControlInterventoAmbReso Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ControlInterventoAmbReso Build(Guid id, Guid commitId, long version)
        {
            var cmd = new ControlInterventoAmbReso(id, commitId, version, _idUtente, _controlDate, _period, _note, _quantity, _description);

            

            return cmd;
        }

    }
}