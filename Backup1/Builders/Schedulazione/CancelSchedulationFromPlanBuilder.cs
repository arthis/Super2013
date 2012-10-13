using System;
using CommonDomain;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Schedulazione
{
    public  class CancelSchedulazioneFromPlanBuilder : ICommandBuilder<CancelSchedulazioneFromPlan>
    {
        private Guid _idUser;
        private bool _deleteGeneratedInterventi;

        public CancelSchedulazioneFromPlanBuilder ByUser(Guid idUser)
        {
            _idUser = idUser;
            return this;
        }

        public CancelSchedulazioneFromPlanBuilder ForAllGeneratedInterventi(bool deleteGeneratedInterventi)
        {
            _deleteGeneratedInterventi = deleteGeneratedInterventi;
            return this;
        }

        public CancelSchedulazioneFromPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CancelSchedulazioneFromPlan Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CancelSchedulazioneFromPlan(id, idCommitId, version, _idUser, _deleteGeneratedInterventi);

            return cmd;
        }



    }
}