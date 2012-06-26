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

        public CloseIntervento Build(Guid id)
        {
            var cmd = new CloseIntervento(id, _idUtente, _closingDate);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}