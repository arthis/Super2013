using System;
using CommonDomain;

namespace Super.Controllo.Commands.Builders
{
    public class CloseInterventoBuilder : ICommandBuilder<CloseIntervento>
    {
        private Guid _idUtente;
        private DateTime _closingDate;

        public CloseInterventoBuilder By(Guid idUtente)
        {
            _idUtente = idUtente;
            return this;
        }

        public CloseInterventoBuilder When(DateTime closingDate)
        {
            _closingDate = closingDate;
            return this;
        }

        public CloseIntervento Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CloseIntervento Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CloseIntervento(id, commitId, version, _idUtente, _closingDate);

            

            return cmd;
        }

    }
}