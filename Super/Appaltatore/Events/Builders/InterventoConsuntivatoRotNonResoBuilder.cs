using System;
using CommonDomain;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoConsuntivatoRotNonResoBuilder : IEventBuilder<InterventoConsuntivatoRotNonReso>
    {
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleAppaltatore;
        private string _idInterventoAppaltatore;
        private string _note;

        #region IEventBuilder<InterventoConsuntivatoRotNonReso> Members

        public InterventoConsuntivatoRotNonReso Build(Guid id, long version)
        {
            return new InterventoConsuntivatoRotNonReso(id, Guid.NewGuid(), version, _idInterventoAppaltatore,
                                                        _dataConsuntivazione, _idCausaleAppaltatore, _note);
        }

        #endregion

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
    }
}