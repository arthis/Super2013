using System;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoConsuntivatoRotManNonResoBuilder
    {
        private Guid _id;
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleAppaltatore;
        private string _note;

        public InterventoConsuntivatoRotManNonResoBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public InterventoConsuntivatoRotManNonResoBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
            return this;
        }

        public InterventoConsuntivatoRotManNonResoBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public InterventoConsuntivatoRotManNonResoBuilder Because(Guid idCausaleAppalatatore)
        {
            _idCausaleAppaltatore = idCausaleAppalatatore;
            return this;
        }
        public InterventoConsuntivatoRotManNonResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoConsuntivatoRotManNonReso Build()
        {
            return new InterventoConsuntivatoRotManNonReso(_id, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleAppaltatore, _note);
        }

    }
}