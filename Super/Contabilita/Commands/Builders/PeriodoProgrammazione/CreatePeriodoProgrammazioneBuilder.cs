using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.PeriodoProgrammazione;

namespace Super.Contabilita.Commands.Builders.PeriodoProgrammazione
{
    public class CreatePeriodoProgrammazioneBuilder : ICommandBuilder<CreatePeriodoProgrammazione>
    {
        private string _description;
        private Interval _interval;

        public CreatePeriodoProgrammazione Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreatePeriodoProgrammazione Build(Guid id, Guid commitId, long version)
        {
            var cmd =  new CreatePeriodoProgrammazione(id, commitId, version,_interval,   _description);

            return cmd;
        }

        public CreatePeriodoProgrammazioneBuilder ForInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }

        public CreatePeriodoProgrammazioneBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


    }
}
