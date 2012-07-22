using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Intervento;

namespace Super.Programmazione.Commands.Builders
{
    public class UpdateInterventoBuilder : ICommandBuilder<UpdateIntervento>
    {
        private string _description;

        public UpdateInterventoBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateIntervento Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateIntervento Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new UpdateIntervento(id, idCommitId, version, _description);

            return cmd;
        }



    }
}