using System;

namespace Super.Controllo.Commands.Builders
{
    public class ReopenInterventoBuilder
    {
        private Guid _id;
        private Guid _idUtente;
        private DateTime _reopeningDate;


        public ReopenInterventoBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public ReopenInterventoBuilder By(Guid idUtente)
        {
            _idUtente = idUtente;
            return this;
        }

        public ReopenInterventoBuilder When(DateTime reopeningDate)
        {
            _reopeningDate = reopeningDate;
            return this;
        }

        public ReopenIntervento Build()
        {
            var cmd = new ReopenIntervento(_id, _idUtente, _reopeningDate);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}