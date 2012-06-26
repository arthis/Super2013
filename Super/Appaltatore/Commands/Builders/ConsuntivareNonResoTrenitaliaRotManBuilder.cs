using System;
using CommonDomain;

namespace Super.Appaltatore.Commands.Builders
{
    public class ConsuntivareNonResoTrenitaliaRotManBuilder : ICommandBuilder<ConsuntivareRotManNonResoTrenitalia>
    {
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleTrenitalia;
        private string _note;

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

        public ConsuntivareRotManNonResoTrenitalia Build(Guid id)
        {
            var cmd = new  ConsuntivareRotManNonResoTrenitalia(id, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleTrenitalia, _note);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}