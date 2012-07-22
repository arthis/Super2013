using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;


namespace Super.Programmazione.Commands.Builders
{
    public class RemoveRuleToSchedulazioneBuilder : ICommandBuilder<RemoveRuleToSchedulazione>
    {


        public RemoveRuleToSchedulazione Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public RemoveRuleToSchedulazione Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new RemoveRuleToSchedulazione(id, idCommitId, version);

            return cmd;
        }



    }
}