using System;
using CommonDomain;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Plan
{
    public  class CancelSchedulazioneFromPlanBuilder : ICommandBuilder<CancelSchedulazioneFromPlan>
    {

        public CancelSchedulazioneFromPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CancelSchedulazioneFromPlan Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CancelSchedulazioneFromPlan(id, idCommitId, version);

            return cmd;
        }



    }
}