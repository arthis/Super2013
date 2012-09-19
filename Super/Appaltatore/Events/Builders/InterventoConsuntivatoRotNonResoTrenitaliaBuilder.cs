using System;
using CommonDomain;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoConsuntivatoRotNonResoTrenitaliaBuilder :
        IEventBuilder<InterventoConsuntivatoRotNonResoTrenitalia>
    {
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleTrenitalia;
        private string _idInterventoAppaltatore;
        private string _note;

        #region IEventBuilder<InterventoConsuntivatoRotNonResoTrenitalia> Members

        public InterventoConsuntivatoRotNonResoTrenitalia Build(Guid id, long version)
        {
            return new InterventoConsuntivatoRotNonResoTrenitalia(id, Guid.NewGuid(), version, _idInterventoAppaltatore,
                                                                  _dataConsuntivazione, _idCausaleTrenitalia, _note);
        }

        #endregion

        public InterventoConsuntivatoRotNonResoTrenitaliaBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
            return this;
        }

        public InterventoConsuntivatoRotNonResoTrenitaliaBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public InterventoConsuntivatoRotNonResoTrenitaliaBuilder Because(Guid idCausaleTrenitalia)
        {
            _idCausaleTrenitalia = idCausaleTrenitalia;
            return this;
        }

        public InterventoConsuntivatoRotNonResoTrenitaliaBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }
    }
}