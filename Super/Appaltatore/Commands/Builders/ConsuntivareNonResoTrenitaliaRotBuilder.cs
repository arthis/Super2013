using System;
using CommonDomain;

namespace Super.Appaltatore.Commands.Builders
{
    public class ConsuntivareNonResoTrenitaliaRotBuilder : ICommandBuilder<ConsuntivareRotNonResoTrenitalia>
    {
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleTrenitalia;
        private string _note;


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

        public ConsuntivareRotNonResoTrenitalia Build(Guid id)
        {
            var cmd = new  ConsuntivareRotNonResoTrenitalia(id, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleTrenitalia, _note);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}