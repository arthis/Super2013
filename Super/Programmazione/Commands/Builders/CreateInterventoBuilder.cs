using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Intervento;

namespace Super.Programmazione.Commands.Builders
{
    public class CreateInterventoBuilder : ICommandBuilder<CreateIntervento>
    {
        private Guid _idUser;
        private string _description;


        public CreateInterventoBuilder ByUser(Guid idUser)
        {
            _idUser = idUser;
            return this;
        }

        public CreateInterventoBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreateIntervento Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateIntervento Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CreateIntervento(id, idCommitId, version, _idUser, _description);

            return cmd;
        }



    }
}