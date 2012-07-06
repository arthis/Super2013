using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Controllo.Events.Builders
{
    public class InterventoRotManControlledResoBuilder : IEventBuilder<InterventoRotManControlledReso>
    {
        private Guid _idUtente;
        private DateTime _controlDate;
        private string _note;
        private WorkPeriod _period;
        private OggettoRotMan[] _oggetti;

        public InterventoRotManControlledResoBuilder By(Guid idUtente)
        {
            _idUtente = idUtente;
            return this;
        }

        public InterventoRotManControlledResoBuilder When(DateTime controlDate)
        {
            _controlDate = controlDate;
            return this;
        }

        public InterventoRotManControlledResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoRotManControlledResoBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public InterventoRotManControlledResoBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public InterventoRotManControlledReso Build(Guid id, long version)
        {
            var cmd = new InterventoRotManControlledReso(id, Guid.NewGuid(), version,  _idUtente, _controlDate, _period, _note, _oggetti);

            return cmd;
        }


    }
}