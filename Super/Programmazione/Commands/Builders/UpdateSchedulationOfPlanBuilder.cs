using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Plan;

namespace Super.Programmazione.Commands.Builders
{
    public class UpdateSchedulationOfPlanBuilder : ICommandBuilder<UpdateSchedulationOfPlan>
    {
        private string _note;

        public UpdateSchedulationOfPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public UpdateSchedulationOfPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateSchedulationOfPlan Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new UpdateSchedulationOfPlan(id, idCommitId, version, _note);

            return cmd;
        }



    }
}