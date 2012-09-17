using System;
using CommonDomain;
using Super.Contabilita.Commands.Intervento;

namespace Super.Contabilita.Commands.Builders.Intervento
{
    public class CancelInterventoPriceOfPlanBuilder : ICommandBuilder<CancelInterventoPriceOfPlan>
    {
        public CancelInterventoPriceOfPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CancelInterventoPriceOfPlan Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CancelInterventoPriceOfPlan(id, commitId, version);
            return cmd;
        }
    }
}