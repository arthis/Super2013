using System;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Appaltatore.Commands.Builders
{

    public class ConsuntivareNonResoRotBuilder
    {
        private Guid _id;
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleAppaltatore;
        private string _note;

        public ConsuntivareNonResoRotBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public ConsuntivareNonResoRotBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
            return this;
        }

        public ConsuntivareNonResoRotBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public ConsuntivareNonResoRotBuilder Because(Guid idCausaleAppalatatore)
        {
            _idCausaleAppaltatore = idCausaleAppalatatore;
            return this;
        }
        public ConsuntivareNonResoRotBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public ConsuntivareRotNonReso Build()
        {
            return new ConsuntivareRotNonReso(_id, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleAppaltatore, _note);
        }

    }
}
