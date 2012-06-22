using System;

namespace Super.Appaltatore.Commands.Builders
{
    public class ConsuntivareNonResoRotManBuilder
    {
        private Guid _id;
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleAppaltatore;
        private string _note;

        public ConsuntivareNonResoRotManBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public ConsuntivareNonResoRotManBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
            return this;
        }

        public ConsuntivareNonResoRotManBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public ConsuntivareNonResoRotManBuilder Because(Guid idCausaleAppalatatore)
        {
            _idCausaleAppaltatore = idCausaleAppalatatore;
            return this;
        }
        public ConsuntivareNonResoRotManBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public ConsuntivareRotManNonReso Build()
        {
            var cmd = new  ConsuntivareRotManNonReso(_id, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleAppaltatore, _note);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}