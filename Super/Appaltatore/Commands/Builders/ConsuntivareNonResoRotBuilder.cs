using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Appaltatore.Commands.Builders
{

    public class ConsuntivareNonResoRotBuilder : ICommandBuilder<ConsuntivareRotNonReso>
    {
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleAppaltatore;
        private string _note;


        public ConsuntivareNonResoRotBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
            return this;
        }

        public ConsuntivareNonResoRotBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public ConsuntivareNonResoRotBuilder Because(Guid idCausaleAppalatatore)
        {
            _idCausaleAppaltatore = idCausaleAppalatatore;
            return this;
        }
        public ConsuntivareNonResoRotBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public ConsuntivareRotNonReso Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ConsuntivareRotNonReso Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new  ConsuntivareRotNonReso(id,idCommitId,version, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleAppaltatore, _note);
            
            

            return cmd;
        }

    }
}
