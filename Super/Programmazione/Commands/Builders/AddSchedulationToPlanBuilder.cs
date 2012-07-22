using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Plan;


namespace Super.Programmazione.Commands.Builders
{
    public class AddSchedulationToPlanBuilder : ICommandBuilder<AddSchedulationToPlan>
    {
        private string _note;

        public AddSchedulationToPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public AddSchedulationToPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddSchedulationToPlan Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new AddSchedulationToPlan(id, idCommitId, version,  _note);

            return cmd;
        }



    }
}