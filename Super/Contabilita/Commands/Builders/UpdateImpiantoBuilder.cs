using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Impianto;

namespace Super.Contabilita.Commands.Builders
{
    public class UpdateImpiantoBuilder : ICommandBuilder<UpdateImpianto>
    {
        Intervall _intervall;
        private string _description;

        public UpdateImpianto Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateImpianto Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateImpianto(id, commitId, version, _intervall, _description);
            
            return cmd;
        }



        public UpdateImpiantoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateImpiantoBuilder ForIntervall(Intervall intervall)
        {
            _intervall = intervall;
            return this;
        }
    }
}