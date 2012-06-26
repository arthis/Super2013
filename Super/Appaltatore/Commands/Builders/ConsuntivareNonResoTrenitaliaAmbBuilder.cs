using System;
using CommonDomain;

namespace Super.Appaltatore.Commands.Builders
{
    public class ConsuntivareNonResoTrenitaliaAmbBuilder : ICommandBuilder<ConsuntivareAmbNonResoTrenitalia>
    {
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleTrenitalia;
        private string _note;


        public ConsuntivareNonResoTrenitaliaAmbBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
            return this;
        }

        public ConsuntivareNonResoTrenitaliaAmbBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public ConsuntivareNonResoTrenitaliaAmbBuilder Because(Guid idCausaleTrenitalia)
        {
            _idCausaleTrenitalia = idCausaleTrenitalia;
            return this;
        }
        public ConsuntivareNonResoTrenitaliaAmbBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public ConsuntivareAmbNonResoTrenitalia Build(Guid id)
        {
            var cmd = new  ConsuntivareAmbNonResoTrenitalia(id, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleTrenitalia, _note);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}