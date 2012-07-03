using System;
using CommonDomain;

namespace Super.Controllo.Commands.Builders
{
    public class AllowControlInterventoBuilder : ICommandBuilder<AllowControlIntervento>
    {
        public AllowControlIntervento Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AllowControlIntervento Build(Guid id, Guid commitId, long version)
        {
            var cmd = new AllowControlIntervento(id, commitId, version);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}