using System;

namespace Super.Appaltatore.Commands.Builders
{
    public class ConsuntivareNonResoTrenitaliaRotManBuilder
    {
        private Guid _id;
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleTrenitalia;
        private string _note;

        public ConsuntivareNonResoTrenitaliaRotManBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public ConsuntivareNonResoTrenitaliaRotManBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
            return this;
        }

        public ConsuntivareNonResoTrenitaliaRotManBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public ConsuntivareNonResoTrenitaliaRotManBuilder Because(Guid idCausaleTrenitalia)
        {
            _idCausaleTrenitalia = idCausaleTrenitalia;
            return this;
        }
        public ConsuntivareNonResoTrenitaliaRotManBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public ConsuntivareRotManNonResoTrenitalia Build()
        {
            var cmd = new  ConsuntivareRotManNonResoTrenitalia(_id, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleTrenitalia, _note);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}