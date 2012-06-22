using System;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoConsuntivatoRotManNonResoTrenitaliaBuilder
    {
        private Guid _id;
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleTrenitalia;
        private string _note;

        public InterventoConsuntivatoRotManNonResoTrenitaliaBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public InterventoConsuntivatoRotManNonResoTrenitaliaBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
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

        public InterventoConsuntivatoRotManNonResoTrenitalia Build()
        {
            return new InterventoConsuntivatoRotManNonResoTrenitalia(_id, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleTrenitalia, _note);
        }

    }
}