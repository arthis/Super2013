using System;

namespace Super.Controllo.Events.Builders
{
    public class InterventoReopenedBuilder
    {
        private Guid _id;
        private Guid _idUtente;
        private DateTime _reopeningDate;


        public InterventoReopenedBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public InterventoReopenedBuilder By(Guid idUtente)
        {
            _idUtente = idUtente;
            return this;
        }

        public InterventoReopenedBuilder When(DateTime reopeningDate)
        {
            _reopeningDate = reopeningDate;
            return this;
        }

        public InterventoReopened Build()
        {
            var cmd = new InterventoReopened(_id, _idUtente, _reopeningDate);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}