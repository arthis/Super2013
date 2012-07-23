using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Impianto;

namespace Super.Contabilita.Commands.Builders
{
    public class UpdateImpiantoBuilder : ICommandBuilder<UpdateImpianto>
    {
        Interval _interval;
        private string _description;

        public UpdateImpianto Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateImpianto Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateImpianto(id, commitId, version, _interval, _description);
            
            return cmd;
        }



        public UpdateImpiantoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateImpiantoBuilder ForInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }
    }
}