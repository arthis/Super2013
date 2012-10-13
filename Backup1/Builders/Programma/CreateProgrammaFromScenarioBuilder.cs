using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using Super.Programmazione.Commands.Programma;

namespace Super.Programmazione.Commands.Builders.Programma
{
    public class CreateProgrammaFromScenarioBuilder : ICommandBuilder<CreateProgrammaFromScenario>
    {

        public CreateProgrammaFromScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateProgrammaFromScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CreateProgrammaFromScenario(id, idCommitId, version);

            return cmd;
        }

    }
}
