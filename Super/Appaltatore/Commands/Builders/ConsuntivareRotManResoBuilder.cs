using System;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Appaltatore.Commands.Builders
{
    public class ConsuntivareRotManResoBuilder
    {
        private Guid _id;
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private WorkPeriod _period;
        private string _note;
        private OggettoRotMan[] _oggetti;
        

        public ConsuntivareRotManResoBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public ConsuntivareRotManResoBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public ConsuntivareRotManResoBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public ConsuntivareRotManResoBuilder ForInterventoAppaltatore(string IdInterventoAppaltatore)
        {
            _idInterventoAppaltatore = IdInterventoAppaltatore;
            return this;
        }

        public ConsuntivareRotManResoBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public ConsuntivareRotManResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }


        public ConsuntivareRotManReso Build()
        {
            var cmd = new  ConsuntivareRotManReso(_id, _idInterventoAppaltatore, _dataConsuntivazione, _period, _note,
                                              _oggetti);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}