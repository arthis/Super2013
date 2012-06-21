using System;

namespace Super.Appaltatore.Commands.Builders
{
    public class ConsuntivareNonResoAmbBuilder
    {
        private Guid _id;
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleAppaltatore;
        private string _note;

        public ConsuntivareNonResoAmbBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public ConsuntivareNonResoAmbBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
            return this;
        }

        public ConsuntivareNonResoAmbBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public ConsuntivareNonResoAmbBuilder Because(Guid idCausaleAppalatatore)
        {
            _idCausaleAppaltatore = idCausaleAppalatatore;
            return this;
        }
        public ConsuntivareNonResoAmbBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public ConsuntivareAmbNonReso Build()
        {
            return new ConsuntivareAmbNonReso(_id, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleAppaltatore, _note);
        }

    }
}