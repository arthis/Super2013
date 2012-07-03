using System;
using CommonDomain;

namespace Super.Appaltatore.Commands.Builders
{
    public class ConsuntivareNonResoAmbBuilder : ICommandBuilder<ConsuntivareAmbNonReso>
    {
        private string _idInterventoAppaltatore;
        private DateTime _dataConsuntivazione;
        private Guid _idCausaleAppaltatore;
        private string _note;


        public ConsuntivareNonResoAmbBuilder ForInterventoAppaltatore(string idInterventoAppaltatore)
        {
            _idInterventoAppaltatore = idInterventoAppaltatore;
            return this;
        }

        public ConsuntivareNonResoAmbBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public ConsuntivareNonResoAmbBuilder Because(Guid idCausaleAppalatatore)
        {
            _idCausaleAppaltatore = idCausaleAppalatatore;
            return this;
        }

        public ConsuntivareNonResoAmbBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public ConsuntivareAmbNonReso Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ConsuntivareAmbNonReso Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new  ConsuntivareAmbNonReso(id,idCommitId,version, _idInterventoAppaltatore, _dataConsuntivazione, _idCausaleAppaltatore, _note);

            

            return cmd;
        }

    }
}