using System;
using CommonDomain;

namespace Super.Appaltatore.Commands.Builders
{
    public class ConsuntivareNonResoRotManBuilder : ICommandBuilder<ConsuntivareRotManNonReso>
    {
        
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleAppaltatore;
        private string _note;

        public ConsuntivareNonResoRotManBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
            return this;
        }

        public ConsuntivareNonResoRotManBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public ConsuntivareNonResoRotManBuilder Because(Guid idCausaleAppalatatore)
        {
            _idCausaleAppaltatore = idCausaleAppalatatore;
            return this;
        }
        public ConsuntivareNonResoRotManBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public ConsuntivareRotManNonReso Build(Guid id)
        {
            var cmd = new  ConsuntivareRotManNonReso(id, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleAppaltatore, _note);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}