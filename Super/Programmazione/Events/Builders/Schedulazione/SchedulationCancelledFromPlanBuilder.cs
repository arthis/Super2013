using System;
using CommonDomain;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public  class SchedulazioneCancelledFromPlanBuilder : IEventBuilder<SchedulazioneCancelledFromPlan>
    {
        private Guid _idUser;
        private bool _deleteGeneratedInterventi;

        public SchedulazioneCancelledFromPlanBuilder ByUser(Guid idUser)
        {
            _idUser = idUser;
            return this;
        }

        public SchedulazioneCancelledFromPlanBuilder ForAllGeneratedInterventi(bool deleteGeneratedInterventi)
        {
            _deleteGeneratedInterventi = deleteGeneratedInterventi;
            return this;
        }

        public SchedulazioneCancelledFromPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulazioneCancelledFromPlan Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new SchedulazioneCancelledFromPlan(id, idCommitId, version,_idUser, _deleteGeneratedInterventi);

            return cmd;
        }



    }
}