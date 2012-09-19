using System;
using CommonDomain;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoConsuntivatoRotManNonResoBuilder : IEventBuilder<InterventoConsuntivatoRotManNonReso>
    {
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleAppaltatore;
        private string _idInterventoAppaltatore;
        private string _note;

        #region IEventBuilder<InterventoConsuntivatoRotManNonReso> Members

        public InterventoConsuntivatoRotManNonReso Build(Guid id, long version)
        {
            return new InterventoConsuntivatoRotManNonReso(id, Guid.NewGuid(), version, _idInterventoAppaltatore,
                                                           _dataConsuntivazione, _idCausaleAppaltatore, _note);
        }

        #endregion

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
    }
}