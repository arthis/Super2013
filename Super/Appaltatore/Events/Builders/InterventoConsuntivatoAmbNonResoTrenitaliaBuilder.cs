using System;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoConsuntivatoAmbNonResoTrenitaliaBuilder
    {
        private Guid _id;
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleTrenitalia;
        private string _note;

        public InterventoConsuntivatoAmbNonResoTrenitaliaBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

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

        public InterventoConsuntivatoAmbNonResoTrenitalia Build()
        {
            return new InterventoConsuntivatoAmbNonResoTrenitalia(_id, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleTrenitalia, _note);
        }

    }
}