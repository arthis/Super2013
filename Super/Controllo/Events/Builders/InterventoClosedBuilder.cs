using System;

namespace Super.Controllo.Events.Builders
{
    public class InterventoClosedBuilder
    {
        private Guid _id;
        private Guid _idUtente;
        private DateTime _closingDate;


        public InterventoClosedBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public InterventoClosedBuilder By(Guid idUtente)
        {
            _idUtente = idUtente;
            return this;
        }

        public InterventoClosedBuilder When(DateTime closingDate)
        {
            _closingDate = closingDate;
            return this;
        }

        public InterventoClosed Build()
        {
            var cmd = new InterventoClosed(_id, _idUtente, _closingDate);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}