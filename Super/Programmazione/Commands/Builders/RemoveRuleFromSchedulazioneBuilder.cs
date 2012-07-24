using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;


namespace Super.Programmazione.Commands.Builders
{
    public class RemoveRuleFromSchedulazioneBuilder : ICommandBuilder<RemoveRuleFromSchedulazione>
    {


        public RemoveRuleFromSchedulazione Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public RemoveRuleFromSchedulazione Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new RemoveRuleFromSchedulazione(id, idCommitId, version);

            return cmd;
        }



    }
}