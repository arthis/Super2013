using System;
using CommonDomain;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoConsuntivatoAmbNonResoTrenitaliaBuilder :
        IEventBuilder<InterventoConsuntivatoAmbNonResoTrenitalia>
    {
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleTrenitalia;
        private string _idInterventoAppaltatore;
        private string _note;

        #region IEventBuilder<InterventoConsuntivatoAmbNonResoTrenitalia> Members

        public InterventoConsuntivatoAmbNonResoTrenitalia Build(Guid id, long version)
        {
            return new InterventoConsuntivatoAmbNonResoTrenitalia(id, Guid.NewGuid(), version, _idInterventoAppaltatore,
                                                                  _dataConsuntivazione, _idCausaleTrenitalia, _note);
        }

        #endregion

        public InterventoConsuntivatoAmbNonResoTrenitaliaBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
            return this;
        }

        public InterventoConsuntivatoAmbNonResoTrenitaliaBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public InterventoConsuntivatoAmbNonResoTrenitaliaBuilder Because(Guid idCausaleTrenitalia)
        {
            _idCausaleTrenitalia = idCausaleTrenitalia;
            return this;
        }

        public InterventoConsuntivatoAmbNonResoTrenitaliaBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }
    }
}