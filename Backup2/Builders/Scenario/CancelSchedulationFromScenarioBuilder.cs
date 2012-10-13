using System;
using CommonDomain;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Scenario
{
    public  class CancelSchedulazioneFromScenarioBuilder : ICommandBuilder<CancelSchedulazioneFromScenario>
    {

        public CancelSchedulazioneFromScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CancelSchedulazioneFromScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CancelSchedulazioneFromScenario(id, idCommitId, version);

            return cmd;
        }



    }
}