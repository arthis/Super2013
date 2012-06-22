using System;

namespace Super.Appaltatore.Commands.Builders
{
    public class ConsuntivareNonResoTrenitaliaRotBuilder
    {
        private Guid _id;
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleTrenitalia;
        private string _note;

        public ConsuntivareNonResoTrenitaliaRotBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public ConsuntivareNonResoTrenitaliaRotBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
            return this;
        }

        public ConsuntivareNonResoTrenitaliaRotBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public ConsuntivareNonResoTrenitaliaRotBuilder Because(Guid idCausaleTrenitalia)
        {
            _idCausaleTrenitalia = idCausaleTrenitalia;
            return this;
        }
        public ConsuntivareNonResoTrenitaliaRotBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public ConsuntivareRotNonResoTrenitalia Build()
        {
            var cmd = new  ConsuntivareRotNonResoTrenitalia(_id, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleTrenitalia, _note);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}