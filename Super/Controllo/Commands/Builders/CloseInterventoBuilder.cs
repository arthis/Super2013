using System;

namespace Super.Controllo.Commands.Builders
{
    public class CloseInterventoBuilder
    {
        private Guid _id;
        private Guid _idUtente;
        private DateTime _closingDate;


        public CloseInterventoBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

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

        public CloseIntervento Build()
        {
            var cmd = new CloseIntervento(_id, _idUtente, _closingDate);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}