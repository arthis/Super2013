using System;
using CommonDomain;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Events.Builders
{

    public class InterventoConsuntivatoRotNonResoBuilder : IEventBuilder<InterventoConsuntivatoRotNonReso>
    {

        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleAppaltatore;
        private string _note;



        public InterventoConsuntivatoRotNonResoBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
            return this;
        }

        public InterventoConsuntivatoRotNonResoBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public InterventoConsuntivatoRotNonResoBuilder Because(Guid idCausaleAppalatatore)
        {
            _idCausaleAppaltatore = idCausaleAppalatatore;
            return this;
        }
        public InterventoConsuntivatoRotNonResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoConsuntivatoRotNonReso Build(Guid id, long version)
        {
            return new InterventoConsuntivatoRotNonReso(id, Guid.NewGuid(), version, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleAppaltatore, _note);
        }

    }
}
