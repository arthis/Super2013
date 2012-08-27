using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.PeriodoProgrammazione;

namespace Super.Contabilita.Commands.Builders.PeriodoProgrammazione
{
    public class UpdatePeriodoProgrammazioneBuilder : ICommandBuilder<UpdatePeriodoProgrammazione>
    {
        private string _description;
        private Interval _interval;

        public UpdatePeriodoProgrammazione Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdatePeriodoProgrammazione Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdatePeriodoProgrammazione(id, commitId, version, _interval,  _description);
            
            return cmd;
        }



        public UpdatePeriodoProgrammazioneBuilder ForInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }

        public UpdatePeriodoProgrammazioneBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        
    }
}