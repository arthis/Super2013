using System;
using CommonDomain;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoConsuntivatoAmbNonResoBuilder : IEventBuilder<InterventoConsuntivatoAmbNonReso>
    {
        private DateTime _dataConsuntivazione;
        private Guid _id;
        private Guid _idCausaleAppaltatore;
        private string _idInterventoAppaltatore;
        private string _note;

        #region IEventBuilder<InterventoConsuntivatoAmbNonReso> Members

        public InterventoConsuntivatoAmbNonReso Build(Guid id, long version)
        {
            return new InterventoConsuntivatoAmbNonReso(id, Guid.NewGuid(), version, _idInterventoAppaltatore,
                                                        _dataConsuntivazione, _idCausaleAppaltatore, _note);
        }

        #endregion

        public InterventoConsuntivatoAmbNonResoBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
            return this;
        }

        public InterventoConsuntivatoAmbNonResoBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public InterventoConsuntivatoAmbNonResoBuilder Because(Guid idCausaleAppalatatore)
        {
            _idCausaleAppaltatore = idCausaleAppalatatore;
            return this;
        }

        public InterventoConsuntivatoAmbNonResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }
    }
}