using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;


namespace Super.Programmazione.Commands.Builders
{
    public class AddRuleToSchedulazioneBuilder : ICommandBuilder<AddRuleToSchedulazione>
    {
        

        public AddRuleToSchedulazione Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddRuleToSchedulazione Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new AddRuleToSchedulazione(id, idCommitId, version);

            return cmd;
        }



    }
}