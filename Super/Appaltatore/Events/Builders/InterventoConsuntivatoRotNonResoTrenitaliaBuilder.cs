using System;
using CommonDomain;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoConsuntivatoRotNonResoTrenitaliaBuilder : IEventBuilder<InterventoConsuntivatoRotNonResoTrenitalia>
    {

        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleTrenitalia;
        private string _note;


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

        public InterventoConsuntivatoRotNonResoTrenitalia Build(Guid id, long version)
        {
            return new InterventoConsuntivatoRotNonResoTrenitalia(id, Guid.NewGuid(), version, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleTrenitalia, _note);
        }

    }
}