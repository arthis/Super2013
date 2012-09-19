using System;
using CommonDomain;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoConsuntivatoRotManNonResoTrenitaliaBuilder :
        IEventBuilder<InterventoConsuntivatoRotManNonResoTrenitalia>
    {
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleTrenitalia;
        private string _idInterventoAppaltatore;
        private string _note;

        #region IEventBuilder<InterventoConsuntivatoRotManNonResoTrenitalia> Members

        public InterventoConsuntivatoRotManNonResoTrenitalia Build(Guid id, long version)
        {
            return new InterventoConsuntivatoRotManNonResoTrenitalia(id, Guid.NewGuid(), version,
                                                                     _idInterventoAppaltatore, _dataConsuntivazione,
                                                                     _idCausaleTrenitalia, _note);
        }

        #endregion

        public InterventoConsuntivatoRotManNonResoTrenitaliaBuilder ForInterventoAppaltatore(
            string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
            return this;
        }

        public InterventoConsuntivatoRotManNonResoTrenitaliaBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public InterventoConsuntivatoRotManNonResoTrenitaliaBuilder Because(Guid idCausaleTrenitalia)
        {
            _idCausaleTrenitalia = idCausaleTrenitalia;
            return this;
        }

        public InterventoConsuntivatoRotManNonResoTrenitaliaBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }
    }
}