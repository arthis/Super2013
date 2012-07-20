using System;
using CommonDomain;

namespace Super.Controllo.Commands.Builders
{
    public class ReopenInterventoBuilder : ICommandBuilder<ReopenIntervento>
    {
        private Guid _idUser;
        private DateTime _reopeningDate;

        public ReopenInterventoBuilder By(Guid idUser)
        {
            _idUser = idUser;
            return this;
        }

        public ReopenInterventoBuilder When(DateTime reopeningDate)
        {
            _reopeningDate = reopeningDate;
            return this;
        }

        public ReopenIntervento Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ReopenIntervento Build(Guid id, Guid commitId, long version)
        {
            var cmd = new ReopenIntervento(id, commitId, version, _idUser, _reopeningDate);

            

            return cmd;
        }

    }
}