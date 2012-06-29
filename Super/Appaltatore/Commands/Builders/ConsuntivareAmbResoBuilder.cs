using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Appaltatore.Commands.Builders
{
    public class ConsuntivareAmbResoBuilder : ICommandBuilder<ConsuntivareAmbReso>
    {
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private WorkPeriod _period;
        private string _note;
        private int _quantity;
        private string _description;


        public ConsuntivareAmbResoBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public ConsuntivareAmbResoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public ConsuntivareAmbResoBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }


        public ConsuntivareAmbResoBuilder ForInterventoAppaltatore(string IdInterventoAppaltatore)
        {
            _idInterventoAppaltatore = IdInterventoAppaltatore;
            return this;
        }

        public ConsuntivareAmbResoBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public ConsuntivareAmbResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }


        public ConsuntivareAmbReso Build(Guid id)
        {
            var cmd = new  ConsuntivareAmbReso(id, _idInterventoAppaltatore, _dataConsuntivazione, _period, _note,_quantity, _description);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }



    }
}